using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ReloadLevel();
    }

    // Reload same scene
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
