using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFragments : MonoBehaviour
{
    public AudioSource WhereAmI = null;

    public AudioSource KeyAudio = null;

    public AudioSource ToolAudio = null;

    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;
    void Start()
    {
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();

        //start of the game
        if (dontdestroyinfo.WhereAmI){
            playWhereAmI();
        }
        //after first puzzle
        else if (dontdestroyinfo.KeyAudio){
            playKeyAudio();
        }
        //after second puzzle
        else if (dontdestroyinfo.ToolAudio){
            playToolAudio();
        }
    }

    void playWhereAmI()
    {
        WhereAmI.Play();
        dontdestroyinfo.WhereAmI = false;
    }
    void playKeyAudio()
    {   
        KeyAudio.Play();
        dontdestroyinfo.KeyAudio = false;
    }
     void playToolAudio()
    {
        ToolAudio.Play();
        dontdestroyinfo.ToolAudio = false;
    }
}