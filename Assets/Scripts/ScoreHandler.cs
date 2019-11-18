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
    }

    public static void updateMostEnemiesHitAtOnce(int _score)
    {
        if (_score > _mostEnemiesKilledAtOnce)
            _mostEnemiesKilledAtOnce = _score;
    }

    public static string getScoreString()
    {
        return "Score: \n" +
            "Wave: " + _wave + "\n" +
            "Enemies killed: " + _enemiesKilled + "\n" +
            "Bullets shot: " + _bulletsShot + "\n" +
            "Most Enemies Killed with one Bullet: " + _mostEnemiesKilledAtOnce;
    }

    public static string getJSONScoreString()
    {
        return "{"+ 
            "\"wave\": \"" + _wave + "\","+
            "\"enemiesKilled\": \"" + _enemiesKilled + "\"," +
            "\"bulletsShot\": \"" + _bulletsShot + "\"," +
            "\"mostEnemiesKilledAtOnce\": \"" + _mostEnemiesKilledAtOnce + "\""+
            "}";
    }
}
