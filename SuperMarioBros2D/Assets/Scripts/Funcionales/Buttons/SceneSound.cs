using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SceneSound : MonoBehaviour
{
    private bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        ReadFile();
        if(mute)
        {
            GetComponent<AudioSource>().mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadFile()
    {
            StreamReader score;
            score = File.OpenText("../SuperMarioBros2D/Assets/Data/Score.txt");
            score.ReadLine();
            score.ReadLine();
            score.ReadLine();
            mute =bool.Parse(score.ReadLine());
            score.Close();
    }
}
