using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepEquip : MonoBehaviour
{
    public string nameScene;
    public GameObject player = null;

    private void Awake()
    {
        if (player == null)
            player = GameObject.Find("Character");
    }

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
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;
        while (!sceneAsync.isDone)
        {
            // wait until it is really finished
            yield return null;
        }
        Debug.Log("Done?");
        OnFinishedLoadingAllScene();
    }

    void enableScene()
    {
        Scene previous = SceneManager.GetActiveScene();
        Scene sceneToLoad = SceneManager.GetSceneByName(nameScene);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(player, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
            SceneManager.UnloadSceneAsync(previous);
        }
    }

    void OnFinishedLoadingAllScene()
    {
        enableScene();
        Debug.Log("Done");
    }
}
