using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public int Coins;
    public int Lives;
    public int TimeGame;
    public int Score;
    private GameObject CoinsUI;
    private GameObject LivesUI;
    private GameObject TimeUI;
    private GameObject ScoreUI;
    private float lastSecond;
    void Start()
    {
        lastSecond = 0;
        TimeGame = 300;
        //Seleccionamos los hijos del canvas para poder acceder a sus campos de texto.
        CoinsUI = transform.GetChild(1).gameObject;
        LivesUI = transform.GetChild(4).gameObject;
        TimeUI = transform.GetChild(3).gameObject;
        ScoreUI = transform.GetChild(0).gameObject;
    }

    
    void Update()
    {
        //Accedemos a los campos de texto y cambiamos su contenido dependiendo de las variables que irán actualizando otros scripts.
        CoinsUI.GetComponent<Text>().text = "COINS\n  "+Coins;
        LivesUI.GetComponent<Text>().text = "LIVES\n  "+Lives;
        TimeUI.GetComponent<Text>().text = "TIME\n  "+TimeGame;
        ScoreUI.GetComponent<Text>().text = "SCORE\n  "+Score;
        updateTime();
    }

    void updateTime()
    {
        if(Time.time - lastSecond >= 1f)
        {
            TimeGame--;
            lastSecond = Time.time;
        }
    }
}
