using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public bool Stealable = true;
    public bool Moveable = false;

    private Material defaultMaterial;
    //Change name to main script for wand controller
    public ControllerPickup attachedController { get; private set; }

    protected virtual void Start() {
        defaultMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    public bool TryAttach(ControllerPickup ctrl, Material selected) {
        if (ctrl.heldItem != null) return false;
        if (attachedController != null) {
            if (!Stealable) return false;
            DetatchController(Vector3.zero);
        }

        attachedController = ctrl;
        OnBeginInteraction();
        if (attachedController == null) return false;
        this.gameObject.GetComponent<MeshRenderer>().material = selected;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        return true;
    }

    public void DetatchController(Vector3 speed) {
        if (attachedController == null) return;
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        OnEndInteraction();
        if (attachedController.heldItem == this) attachedController.OnItemDetach(this);
        else Debug.LogError("Controller state (HeldItem) was incorrect. Tried to detach " + this + " while holding " + attachedController.heldItem);
        this.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        attachedController = null;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed;
    }

    //Called when the user begins interacting with this object. 
    protected virtual void OnBeginInteraction() { }

    //Called  when the user stops interacting with this object. 
    protected virtual void OnEndInteraction() { }

    //No need for OnInteractionStay. You can issue updates for your object in Update() and check if attachedController is null;

    //Called by WandController when an unattached controller overlaps this object's collider.
    public virtual void OnHoverEnter(ControllerPickup ctrl, Material hover) {
        this.gameObject.GetComponent<MeshRenderer>().material = hover;
    }

    //Called by WandController when an unattached controller overlaps this object's collider.
    public virtual void OnHoverExit(ControllerPickup ctrl) {
        this.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    //Called by WandController on each frame an unattached controller overlaps this object's collider.
    public virtual void OnHoverStay(ControllerPickup ctrl, Material hover) {
        if (this.gameObject.GetComponent<MeshRenderer>().material == defaultMaterial)
        this.gameObject.GetComponent<MeshRenderer>().material = hover;
    }
}
