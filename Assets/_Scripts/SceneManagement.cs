using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{ 
    public void GoToNextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
