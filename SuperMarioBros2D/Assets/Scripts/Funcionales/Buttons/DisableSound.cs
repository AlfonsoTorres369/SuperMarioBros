using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSound : MonoBehaviour
{
    private GameObject[] soundObj;
    private GameObject[] enemySound;
    private GameObject mario;
    public bool muteSound;
    private GameObject gameover;
    private GameObject pauseController;
    // Start is called before the first frame update
    void Start()
    {
        pauseController = GameObject.Find("PauseController");
        enemySound = GameObject.FindGameObjectsWithTag("Turtle");
        gameover = GameObject.Find("Score&SceneController");
        mario = GameObject.FindWithTag("Mario");
        soundObj = GameObject.FindGameObjectsWithTag("Box");

        if(muteSound)
        {
            mario.GetComponent<AudioSource>().mute = true;
            GetComponent<AudioSource>().Pause();
            pauseController.GetComponent<AudioSource>().mute = true;
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = true;
            }
            for(int i=0; i<enemySound.Length; i++)
            {
                enemySound[i].GetComponent<AudioSource>().mute = true;
                enemySound[i].transform.GetChild(0).gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
        //Aquí, acceder al fichero Score para ver si la última vez que se jugó estaba en silencio o no.
        //En la escen de GameOver y Victory acceder a Score para ver la opción de sonido.
    }

    // Update is called once per frame
    void Update()
    {
        GetBoxes();
        GetTurtles();
        UpdateTurtles();
        if(Input.GetKeyDown(KeyCode.M) && !muteSound)
        {
            muteSound = true;
            gameover.GetComponent<GameOver>().ReloadOptions();
            pauseController.GetComponent<AudioSource>().mute = true;
            mario.GetComponent<AudioSource>().mute = true;
            GetComponent<AudioSource>().Pause();
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = true;
            }
            for(int i=0; i<enemySound.Length; i++)
            {
                enemySound[i].GetComponent<AudioSource>().mute = true;
                enemySound[i].transform.GetChild(0).gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.M) && muteSound)
        {
            muteSound = false;
            pauseController.GetComponent<AudioSource>().mute = false;
            gameover.GetComponent<GameOver>().ReloadOptions();
            mario.GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().UnPause();
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = false;
            }
            for(int i=0; i<enemySound.Length; i++)
            {
                enemySound[i].GetComponent<AudioSource>().mute = false;
                enemySound[i].transform.GetChild(0).gameObject.GetComponent<AudioSource>().mute = false;
            }
        }
    }

    void GetTurtles()
    {
        enemySound = GameObject.FindGameObjectsWithTag("Turtle"); 
    }
    void GetBoxes()
    {
        soundObj = GameObject.FindGameObjectsWithTag("Box");
    }

    void UpdateTurtles()
    {
        if(!muteSound)
        {
            for(int i=0; i<enemySound.Length; i++)
            {
                enemySound[i].GetComponent<AudioSource>().mute = false;
                enemySound[i].transform.GetChild(0).gameObject.GetComponent<AudioSource>().mute = false;
            }
        }
        if(muteSound)
        {
            for(int i=0; i<enemySound.Length; i++)
            {
                enemySound[i].GetComponent<AudioSource>().mute = true;
                enemySound[i].transform.GetChild(0).gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
    }
}
