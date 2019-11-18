using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{

    public Button startButton = null;

    void Start()
    {
        if(startButton != null)
        {
            Button btn = startButton.GetComponent<Button>();
            btn.onClick.AddListener(StartGame);

        }
        unloadInactiveScenes();

    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainSzene");
        ScoreHandler.reset();

        unloadInactiveScenes();

    }

    public void GameOver()
    {

        SceneManager.LoadScene("GameOverSzene");
        unloadInactiveScenes();
    }

    private void unloadInactiveScenes()
    {
        List<Scene> szenesToUnload = new List<Scene>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!SceneManager.GetActiveScene().Equals(scene))
                szenesToUnload.Add(scene);
        }

        for (int i = 0; i < szenesToUnload.Count; i++)
        {
            SceneManager.UnloadSceneAsync(szenesToUnload[i]);
        }

    }
}
