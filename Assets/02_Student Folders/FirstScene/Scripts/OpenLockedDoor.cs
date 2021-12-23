using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public bool locked = true;
    public bool isClosed = true;
    public Transform Door;
    public float speed = 2f;
    public Collider triggerZone;

    Vector3 door1DefaultPos = new Vector3(0, 0, 0.3f);
    //Vector3 door2DefaultPos = new Vector3(1.9f, 0, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //deur gaat open na unlock
        if (!isClosed && Door.position.z <= 31.5f){
            Door.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // else if (!isClosed && Door.position.z >= 31.5f){

        // }
    }

    void OnTriggerEnter (Collider other)
    {
        //als speler sleutel heeft kan die door unlocken
        if (!locked)
        {
            UnlockDoor();
            // timer = timerlength;
            // opening = true;
        }
    }

    void UnlockDoor(){
        isClosed = false;
        Debug.Log("Door should be opening now");
        //yield return new WaitForSeconds(8.4f);
    }

}
