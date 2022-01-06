using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonedAudioTrigger : MonoBehaviour
{
    public AudioSource AbandonedAudioSource = null;

    //dont destroy info
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    //audio van puzzle memory kan nog spelen
    public AudioFragments MemoryAudio = null;

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
        if (dontdestroyinfo.AbandonedAudio && !MemoryAudio.KeyAudio.isPlaying){
            AbandonedAudioSource.Play();
            dontdestroyinfo.AbandonedAudio = false;
        }
    }
    
}
