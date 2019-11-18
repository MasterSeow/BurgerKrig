using UnityEngine;
using System.Runtime.InteropServices;

public class BrowserCommunication : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void sendResultJsonString(string str);

  
    void Start()
    {
        sendResultJsonString(ScoreHandler.getJSONScoreString());
    }
}
