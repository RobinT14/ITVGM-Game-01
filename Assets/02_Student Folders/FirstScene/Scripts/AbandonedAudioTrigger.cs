using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonedAudioTrigger : MonoBehaviour
{
    public AudioSource AbandonedAudioSource = null;

    //dont destroy info
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    public Collider TriggerZone;


    // Start is called before the first frame update
    void Start()
    {
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(){
        if (dontdestroyinfo.AbandonedAudio){
            AbandonedAudioSource.Play();
            dontdestroyinfo.AbandonedAudio = false;
        }
    }
    
}
