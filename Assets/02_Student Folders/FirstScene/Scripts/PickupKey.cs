using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    Pickup m_Pickup;
    public GameObject ObjectiveKeyParent;
    ObjectivePickupItem ObjectiveMessage;

    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    public OpenLockedDoor Doorlock;

    void Start()
    {
        //message van de key
        ObjectiveMessage = ObjectiveKeyParent.GetComponent<ObjectivePickupItem>();
        //dont destroy
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        Health playerHealth = player.GetComponent<Health>();
        // if (playerHealth.canPickup())
        // {
            Doorlock.locked = false;

            dontdestroyinfo.ShowKeyMessage = false;
           
            m_Pickup.PlayPickupFeedback();

            //alleen wanneer de message is unlockt moet die gecomplete worden
            if (ObjectiveKeyParent.activeSelf){
                ObjectiveMessage.ObjectiveCompletion();
            }

            Destroy(gameObject);
        //}
    }
}
