using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class LevelManagement : MonoBehaviour
{

    public Button startButton = null;


    [DllImport("__Internal")]
    private static extern void sendResultJsonString(string str);


    void Start()
    {
        if(startButton != null)
        {
            Button btn = startButton.GetComponent<Button>();
            btn.onClick.AddListener(StartGame);
            #if !UNITY_EDITOR && UNITY_WEBGL
                WebGLInput.captureAllKeyboardInput = false;
            #endif

        }
        unloadInactiveScenes();

    }

    public void StartGame()
    {

        #if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = true;
        #endif

        SceneManager.LoadScene("MainSzene");
        ScoreHandler.reset();
        ScoreHandler.gameStart();

        unloadInactiveScenes();
    }

    public void GameOver()
    {

        SceneManager.LoadScene("GameOverSzene");
        unloadInactiveScenes();
        ScoreHandler.gameOver();
        sendResultJsonString(ScoreHandler.getJSONScoreString());
        WebGLInput.captureAllKeyboardInput = false;

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
