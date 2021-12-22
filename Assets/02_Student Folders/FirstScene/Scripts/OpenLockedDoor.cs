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
        if (!isClosed){
            Door.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (!locked)
        {
            isClosed = false;
            // timer = timerlength;
            // opening = true;
        }
    }
}
