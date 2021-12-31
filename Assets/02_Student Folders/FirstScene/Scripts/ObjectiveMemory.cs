using UnityEngine;

[RequireComponent(typeof(Objective))]
public class ObjectiveMemory : MonoBehaviour
{
    Objective m_Objective;
    Pickup m_Pickup;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectivePickupItem>(m_Objective, this, gameObject);

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupItem>(m_Pickup, this, gameObject);

        // subscribe to the onPick action on the Pickup component
        // m_Pickup.onPick += OnPickup;
    }

    public void ObjectiveCompletion()
    {
        if (m_Objective.isCompleted)
            return;

        // this will trigger the objective completion
        // it works even if the player can't pickup the item (i.e. objective pickup healthpack while at full heath)
        m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}
