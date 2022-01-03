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

        if (dontdestroyinfo.WhereAmI){
            playWhereAmI();
        }
        else if (dontdestroyinfo.KeyAudio){
            playKeyAudio();
        }
        else if (dontdestroyinfo.ToolAudio){
            playToolAudio();
        }
    }

    // Update is called once per frame
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