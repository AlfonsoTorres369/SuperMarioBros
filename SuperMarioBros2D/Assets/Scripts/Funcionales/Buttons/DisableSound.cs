using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSound : MonoBehaviour
{
    private GameObject[] soundObj;
    private GameObject mario;
    public bool muteSound;
    private GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Score&SceneController");
        mario = GameObject.FindWithTag("Mario");
        soundObj = GameObject.FindGameObjectsWithTag("Box");
        if(muteSound)
        {
            mario.GetComponent<AudioSource>().mute = true;
            GetComponent<AudioSource>().Pause();
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = true;
            }
        }
        //Aquí, acceder al fichero Score para ver si la última vez que se jugó estaba en silencio o no.
        //En la escen de GameOver y Victory acceder a Score para ver la opción de sonido.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !muteSound)
        {
            muteSound = true;
            gameover.GetComponent<GameOver>().ReloadOptions();
            
            mario.GetComponent<AudioSource>().mute = true;
            GetComponent<AudioSource>().Pause();
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.M) && muteSound)
        {
            muteSound = false;
            gameover.GetComponent<GameOver>().ReloadOptions();
            mario.GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().UnPause();
            for(int i=0; i<soundObj.Length; i++)
            {
                soundObj[i].GetComponent<AudioSource>().mute = false;
            }
        }
    }
}
