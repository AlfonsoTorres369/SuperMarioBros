using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum State {Pause, Play};
    public State gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = State.Play;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
        if(Input.GetKeyDown(KeyCode.P) && gameState == State.Play)
        {
            Debug.Log("Pausa");
            gameState = State.Pause;
            Time.timeScale = 0.0f;
        }
        if(Input.GetKeyDown(KeyCode.P) && gameState == State.Pause)
        {
            gameState = State.Play;
            Time.timeScale = 1.0f;
        }
    }
}
