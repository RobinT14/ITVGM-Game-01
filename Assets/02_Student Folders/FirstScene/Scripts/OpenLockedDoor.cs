using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public bool locked = true;
    public bool isClosed = true;

    //Audio voor soundeffect openen
    public AudioSource soundSource = null;

    //audio van abandoned trigger
    public AbandonedAudioTrigger AbandonedSource;

    //audio voor audiofragment
    public AudioSource LockedDoorAudio = null;

    //dont destroy info zodat deur open blijft staan na memories
    public GameObject PlayerPositionObject;
    DontDestroy dontdestroyinfo;

    //voor audio en objective message
    public GameObject ObjectiveMessage;
    public Transform Door;
    public float speed = 2f;
    public Collider triggerZone;

    Vector3 OpenPosition = new Vector3(-1.84f, -0.96f, 31.5f);
    //Vector3 door2DefaultPos = new Vector3(1.9f, 0, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        PlayerPositionObject = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PlayerPositionObject.GetComponent<DontDestroy>();

        //als je message had geactiveerd voor de memory
        //dan moet message weer tezien zijn na de mamory
        if (dontdestroyinfo.DoorNoticed && dontdestroyinfo.ShowKeyMessage){
            ObjectiveMessage.SetActive(true);
        }//or the message needs to come after the first memory 
        else if(!dontdestroyinfo.ShowTriggerobj1 && dontdestroyinfo.DoorLocked){
            ObjectiveMessage.SetActive(true);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //is puzzle2 net opgelost? Dan moet de deur nog open staan
        if (!dontdestroyinfo.ShowTriggerobj2 && isClosed){
            Door.position = OpenPosition;
            isClosed = false;
        }
        //deur gaat open na unlock
        else if (!isClosed && Door.position.z <= 31.5f && dontdestroyinfo.ShowTriggerobj2){
            Door.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        //als speler sleutel heeft kan die door unlocken
        if (!locked)
        {        
            UnlockDoor();
        }
        //als de speler geen sleutel heeft moet message komen dat die sleutel moet zoeken
        else if (locked && !dontdestroyinfo.DoorNoticed && dontdestroyinfo.ShowKeyMessage){
            ObjectiveMessage.SetActive(true);
            dontdestroyinfo.DoorNoticed = true;
        }
        //als de vent nog locked is en er niet al een audio speelt moet er een audio komt
        if (!LockedDoorAudio.isPlaying && locked && !AbandonedSource.AbandonedAudioSource.isPlaying && dontdestroyinfo.DoorLocked){
                LockedDoorAudio.Play();
            }
    }

    void UnlockDoor(){

        if (dontdestroyinfo.DoorLocked){
            dontdestroyinfo.DoorLocked = false;
            isClosed = false;
            soundSource.Play();
            Debug.Log("Door should be opening now");
            //yield return new WaitForSeconds(8.4f);
        }
    }

}
