using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; 

public class GameSceneManager : MonoBehaviour
{
public GameObject endCreditsUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void Reload()
    {
        StartCoroutine(ReloadRoutine());
    }
    IEnumerator ReloadRoutine()
    {
            yield return new WaitForSeconds(0.1f);

        if (endCreditsUI != null)
            endCreditsUI.SetActive(false);
        
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindex);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Stop playing in the Editor
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        // On WebGL, Application.Quit() doesn’t work.
        // Instead, use a JavaScript plugin or show a message if you want.
        Debug.Log("Quit not supported on WebGL. Closing tab or window manually.");
#else
        // Quit standalone app
        Application.Quit();
#endif
    }
}

