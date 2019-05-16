using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{

    private Text t;
    void Start()
    {
        t = gameObject.GetComponent<Text>();
        t.text = "000000";   
    }

    
}
