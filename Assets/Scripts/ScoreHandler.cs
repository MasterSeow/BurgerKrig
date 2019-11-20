using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreHandler : object
{
    private static int _wave = 0;
    private static int _enemiesKilled = 0;
    private static int _bulletsShot = 0;
    private static int _mostEnemiesKilledAtOnce = 0;
    private static float _timeWastedInThisGame = 0;


    private static float _startTime;

    private static int noHitBullets = 0;
    private static int finalScoreCounter = 0;


    public static void gameStart()
    {
        _startTime = Time.time;
    }

    public static void gameOver()
    {
        _timeWastedInThisGame = Time.time - _startTime;
    }

    public static void setWave(int wave)
    {
        _wave = wave;
    }
    public static void incEnemiesKilled()
    {
        _enemiesKilled++;
    }

    public static void incBulletsShot()
    {
       _bulletsShot++;
    }

    public static void reset()
    {
        _wave = 0;
        _enemiesKilled = 0;
        _bulletsShot = 0;
        _mostEnemiesKilledAtOnce = 0;
        finalScoreCounter = 0;
        noHitBullets = 0;
    }

    public static void updateMostEnemiesHitAtOnce(int _score)
    {
        if (_score == 0)
            noHitBullets++;

        for(int i = _score; i > 0; i--)
            finalScoreCounter += i;
 
        if (_score > _mostEnemiesKilledAtOnce)
            _mostEnemiesKilledAtOnce = _score;
    }

    private static int applyMultipliersToScore(int score)
    {
        float multiplier = 1;

        if(_bulletsShot>0)
            multiplier *=1 - ((float)noHitBullets / ((float)_bulletsShot));
        Debug.Log("Multi: " + multiplier);
        return (int)((float)score * multiplier);
    }

    public static string getScoreString()
    {
        return "Score: "+ applyMultipliersToScore(finalScoreCounter) + "\n Wave: " + _wave;
    }

    public static string getJSONScoreString()
    {
        return "{"+
            "\"finalScore\": \"" + applyMultipliersToScore(finalScoreCounter) + "\"," +
            "\"wave\": \"" + _wave + "\","+
            "\"enemiesKilled\": \"" + _enemiesKilled + "\"," +
            "\"bulletsShot\": \"" + _bulletsShot + "\"," +
            "\"mostEnemiesKilledAtOnce\": \"" + _mostEnemiesKilledAtOnce + "\"," +
            "\"timeWastedInThisGame\": \"" + _timeWastedInThisGame + "\"" +
            "}";
    }

}
