using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextDisplay : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = ScoreHandler.getScoreString();
    }

    void Update()
    {
        GetComponent<Text>().text = ScoreHandler.getScoreString();
    }
}
