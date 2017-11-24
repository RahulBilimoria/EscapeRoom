using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerPickup : MonoBehaviour {

    public SteamVR_Controller.Device input;
    public Interactable heldItem;

    private Material selectedMaterial;
    private Material hoverMaterial;
    private Material invalidMaterial;
    private Material defaultMaterial;

    private Vector3 speed;
    private Vector3 lastPos;

    // Use this for initialization
    void Start () {
        var trackedObj = this.GetComponent<SteamVR_TrackedObject>();
        input = SteamVR_Controller.Input((int)trackedObj.index);

        selectedMaterial = Resources.Load<Material>("Materials/Selected");
        hoverMaterial = Resources.Load<Material>("Materials/Hovered");
        invalidMaterial = Resources.Load<Material>("Materials/Invalid Interaction");

        lastPos = transform.position;

        if (gameObject.layer != LayerMask.NameToLayer("Controllers")) Debug.LogError("Controllers should be in 'Controllers' Collision Layer");
    }
	
	// Update is called once per frame
	void Update () {
        var currentPos = transform.position;
        speed = (currentPos - lastPos) * 100;
        lastPos = currentPos;
        selectObject();
	}

    private void selectObject() {
        if (heldItem != null) {
            if (input.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
                if (heldItem.Moveable)
                    heldItem.DetatchController(speed);
                else
                    heldItem.DetatchController(Vector3.zero);
            }
        }
    }

    public void OnItemDetach(Interactable item) {
        Destroy(gameObject.GetComponent<FixedJoint>());
        heldItem = null;
    }

    private void OnTriggerEnter(Collider other) {
        var interactable = other.attachedRigidbody.GetComponent<Interactable>();
        if (interactable == null) return;
        interactable.OnHoverEnter(this, hoverMaterial);
    }

    //TRY HAVING THE INTERACTABLE ATTACH THE FIXEDJOINT TO THE CONTROLLER

    private void OnTriggerStay(Collider other) {
        var interactable = other.attachedRigidbody.GetComponent<Interactable>();
        if (interactable == null) return;
        if (input.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
            if (!interactable.TryAttach(this, selectedMaterial)) return;
            heldItem = interactable;
            if (interactable.gameObject.layer == LayerMask.NameToLayer("Door Handle")) return;
            this.gameObject.AddComponent<FixedJoint>().connectedBody = other.attachedRigidbody;
        }
        else
            interactable.OnHoverStay(this,  hoverMaterial);
    }

    private void OnTriggerExit(Collider other) {
        other.attachedRigidbody.GetComponent<Interactable>().OnHoverExit(this);
    }
}
