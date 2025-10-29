using System;
using Interaction;
using System.Security.Cryptography;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour, Pickupable
{
    [SerializeField]
    Rigidbody pickupRigidBody;

    [SerializeField]
    Collider pickupCollider;

    [SerializeField]
    Vector3 pickupPositionOffset;


    public virtual string MessageInteract => "Press E to pick up the object";

    public void Interact(InteractableControl interactableControl)
    {
        var pickupController = interactableControl.GetComponent<PickupController>();

        Grab(pickupController);
    }

    public virtual void Grab(PickupController pickupController)
    {
        if(pickupController == null || pickupController.HasPickupable)
        {
            return;
        }

        pickupController.GrabPickUp(this);

        SetPhysicsValues(true);

    }

    public virtual void Drop(PickupController pickupController)
    {
        transform.parent = null;

        SetPhysicsValues(false);
    }

    public void SetPositionInParent(Transform newParent)
    {
        transform.parent = newParent;
        transform.localPosition = pickupPositionOffset;
        transform.localRotation = Quaternion.identity;

    }
    public virtual void Use()
    {
       
        Debug.Log("Using the pickupable object");

    }

    void SetPhysicsValues(bool wasPickedUp)
    {
        pickupRigidBody.isKinematic = wasPickedUp;
        pickupCollider.enabled = !wasPickedUp;

    }
}
