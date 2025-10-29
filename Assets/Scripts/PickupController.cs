using System;
using System.Security.Cryptography;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    Transform pickupHolder;

    Pickupable currentPickupable;

    public bool HasPickupable => currentPickupable != null;

    public void GrabPickUp(Pickupable newPickup)
    {
        currentPickupable = newPickup;

        currentPickupable.SetPositionInParent(pickupHolder);
    }

    public void Update()
    {
        CheckDropInput();

        CheckUsePickupInput();
    }   
    
    void CheckDropInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) && HasPickupable)
        {
            currentPickupable.Drop(this);
            currentPickupable = null;
        }
    }

    void CheckUsePickupInput()
    {
        if (Input.GetMouseButtonDown(0) && HasPickupable)
        {
            currentPickupable.Use();
        }
    }
}
