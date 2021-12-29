using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTool : MonoBehaviour
{
    Pickup m_Pickup;
    public OpenVent Vent;

    void Start()
    {
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
            Vent.locked = false;
           
            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        //}
    }
}

