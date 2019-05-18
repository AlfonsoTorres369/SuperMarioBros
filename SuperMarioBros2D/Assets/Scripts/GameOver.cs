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
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        scoreboard = canvas.GetComponent<Scoreboard>();
        DataCharge();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("holi");
    }
    public void LoadNewScene()
    {
        if(scoreboard.Lives > 0)
        {
            StreamWriter score;
            score = File.CreateText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.WriteLine(scoreboard.Score);
            score.WriteLine(scoreboard.Coins);
            score.WriteLine(scoreboard.Lives);
            score.Close();
            //SceneManager.LoadScene("RetryScene");
        }
        if(scoreboard.Lives == 0)
        {
            StreamWriter score;
            score = File.CreateText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.WriteLine("0");
            score.WriteLine("0");
            score.WriteLine("3");
            score.Close();
            //SceneManager.LoadScene("GameOverScene");

        }
    }

    public void DataCharge()
    {
            StreamReader score;
            score = File.OpenText("../SuperMarioBros2D/Assets/Data/Score.txt");
            scoreboard.Score = Int32.Parse(score.ReadLine());
            scoreboard.Coins = Int32.Parse(score.ReadLine());
            scoreboard.Lives = Int32.Parse(score.ReadLine());
            score.Close();
            File.Delete("../SuperMarioBros2D/Assets/Data/Score.txt");
    }
}
