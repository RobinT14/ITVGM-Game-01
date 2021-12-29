using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVent : MonoBehaviour
{
    public bool locked = true;
    public bool isClosed = true;

    //dont destroy info zodat deur open blijft staan na memories
    public GameObject PlayerPositionObject;
    DontDestroy dontdestroyinfo;
    public Transform Vent;
    public float speed = 2f;
    public Collider triggerZone;

    Vector3 OpenPosition = new Vector3(-15.84f, -6.59f, 15.75f);
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
        //rooster moet open blijven nadat t is geopend
        // if (!dontdestroyinfo.ShowTriggerobj2 && isClosed){
        //     Vent.position = OpenPosition;
        //     isClosed = false;
        // }
        //roostergaat open na unlock
        if (!isClosed && Vent.position.x >= -15.84 ){
            Debug.Log("Door should be opening now");
            Vent.Translate(Vector3.left * Time.deltaTime * speed);
        }

    }

    void OnTriggerEnter (Collider other)
    {
        //als speler sleutel heeft kan die door unlocken
        if (!locked)
        {
            UnlockDoor();
        }
    }

    void UnlockDoor(){
        isClosed = false;
        
        //yield return new WaitForSeconds(8.4f);
    }

}


