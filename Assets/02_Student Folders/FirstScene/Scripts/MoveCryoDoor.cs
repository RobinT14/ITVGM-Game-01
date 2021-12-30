using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCryoDoor : MonoBehaviour
{
    public Transform Door;
    public float speed = 2f;
    Vector3 newPosition = new Vector3(-2, -1.896437f, -1);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, Time.deltaTime * speed);
        // Door.Translate(Vector3.forward * Time.deltaTime * speed);

    }

}