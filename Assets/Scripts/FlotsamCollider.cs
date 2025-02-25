using UnityEngine;

public class FlotsamCollider : MonoBehaviour
{
    public bool PlayerContact { get; set; } = false;

    void OnTriggerEnter(Collider trigger)
    {
        PlayerContact = true;
    }

    void OnTriggerExit(Collider trigger)
    {
        PlayerContact = false;
    }
}
