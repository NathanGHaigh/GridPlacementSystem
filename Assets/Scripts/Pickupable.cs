using UnityEngine;
using Interaction;


public interface Pickupable : Interactable
{
    public void Grab(PickupController pickupController);
    public void Drop(PickupController pickupController);
    public void SetPositionInParent(Transform newParent);
    public void Use();
}
