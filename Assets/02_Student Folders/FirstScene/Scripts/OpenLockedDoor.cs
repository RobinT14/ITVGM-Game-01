using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public bool locked = true;
    public bool isClosed = true;

    //dont destroy info zodat deur open blijft staan na memories
    public GameObject PlayerPositionObject;
    DontDestroy dontdestroyinfo;

    //voor audio en objective message
    public bool DoorNoticed = false;
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
        else if (locked && !DoorNoticed && dontdestroyinfo.ShowKeyMessage){
            //insert audio fragment bryan eens in de zoveel keer dat die de trigger tegen komt
            ObjectiveMessage.SetActive(true);
            DoorNoticed = true;
        }
    }

    void UnlockDoor(){
        isClosed = false;
        Debug.Log("Door should be opening now");
        //yield return new WaitForSeconds(8.4f);
    }

}
