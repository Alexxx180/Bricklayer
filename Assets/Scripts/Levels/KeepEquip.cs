using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepEquip : MonoBehaviour
{
    public string nameScene;
    public GameObject player = null;

    // Find main hero to transport with equipment
    private void Awake()
    {
        if (player == null)
            player = GameObject.Find("Character");
    }

    // Go through portal
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(loadScene());
        }
    }
    private AsyncOperation sceneAsync;

    IEnumerator loadScene()
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene 0.9
        while (scene.progress < 0.9f)
        {
            yield return null;
        }
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;
        while (!sceneAsync.isDone)
        {
            // wait until it is really finished
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }

    void enableScene()
    {
        Scene previous = SceneManager.GetActiveScene();
        Scene sceneToLoad = SceneManager.GetSceneByName(nameScene);
        if (sceneToLoad.IsValid())
        {
            SceneManager.MoveGameObjectToScene(player, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
            SceneManager.UnloadSceneAsync(previous);
        }
    }

    // Only then all is done enable scene
    void OnFinishedLoadingAllScene()
    {
        enableScene();
    }
}
