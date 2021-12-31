using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showEscapePlan : MonoBehaviour
{
    public Canvas thePlan;
public OpenVent vent;    

    // Start is called before the first frame update
    void Start()
    {
//       this.SetActive(false);
 thePlan.GetComponent<Canvas> ().enabled = false;
//vent = gameObject.GetComponent<OpenVent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!vent.isClosed) 
        {
            thePlan.GetComponent<Canvas> ().enabled = true;
        }
    }
}
