using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereAmIAudio : MonoBehaviour
{
    public AudioSource source = null;

    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;
    void Start()
    {
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();

        if (dontdestroyinfo.WhereAmI){
            playaudio();
        }
    }

    // Update is called once per frame
    void playaudio()
    {
        source.Play();
        dontdestroyinfo.WhereAmI = false;
    }
}
