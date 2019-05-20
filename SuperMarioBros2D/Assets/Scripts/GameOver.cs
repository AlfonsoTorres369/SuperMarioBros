using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
public class GameOver : MonoBehaviour
{
    private GameObject canvas;
    private Scoreboard scoreboard;
    private GameObject cam;
    
    // Start is called before the first frame update
    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        canvas = GameObject.Find("Canvas");
        scoreboard = canvas.GetComponent<Scoreboard>();
        DataCharge();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Reload()
    {
        scoreboard.Lives--;
        if(scoreboard.Lives > 0)
        {
            File.Delete("../SuperMarioBros2D/Assets/Data/Score.txt");
            StreamWriter score;
            score = File.CreateText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.WriteLine(scoreboard.Score);
            score.WriteLine(scoreboard.Coins);
            score.WriteLine(scoreboard.Lives);
            score.WriteLine(cam.GetComponent<DisableSound>().muteSound);
            score.Close();
            SceneManager.LoadScene("World 1-1");
        }
        if(scoreboard.Lives == 0)
        {
            File.Delete("../SuperMarioBros2D/Assets/Data/Score.txt");
            StreamWriter score;
            score = File.CreateText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.WriteLine("0");
            score.WriteLine("0");
            score.WriteLine("3");
            score.WriteLine(cam.GetComponent<DisableSound>().muteSound);
            score.Close();
            SceneManager.LoadScene("GameOverScene");

        }
    }

    public void DataCharge()
    {
            StreamReader score;
            score = File.OpenText("../SuperMarioBros2D/Assets/Data/Score.txt");
            scoreboard.Score = Int32.Parse(score.ReadLine());
            scoreboard.Coins = Int32.Parse(score.ReadLine());
            scoreboard.Lives = Int32.Parse(score.ReadLine());
            cam.GetComponent<DisableSound>().muteSound = bool.Parse(score.ReadLine());
            score.Close();
    }
    public void ReloadOptions()
    {
            File.Delete("../SuperMarioBros2D/Assets/Data/Score.txt");
            StreamWriter score;
            score = File.CreateText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.WriteLine("0");
            score.WriteLine("0");
            score.WriteLine("3");
            score.WriteLine(cam.GetComponent<DisableSound>().muteSound);
            score.Close();
    }
}
