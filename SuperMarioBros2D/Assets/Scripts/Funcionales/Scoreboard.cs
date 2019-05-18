using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public int Coins;
    public int Lives;
    public int Time;
    public int Score;
    private GameObject CoinsUI;
    private GameObject LivesUI;
    private GameObject TimeUI;
    private GameObject ScoreUI;
    void Start()
    {
        Time = 300;
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
        TimeUI.GetComponent<Text>().text = "TIME\n  "+Time;
        ScoreUI.GetComponent<Text>().text = "SCORE\n  "+Score;
    }
}
