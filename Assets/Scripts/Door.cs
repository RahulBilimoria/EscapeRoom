using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public float rotateLimit = 15;
    public bool locked = false;
    public GameObject key;
    public int type = 0;

    [Header("Direction")]
    //[Range(0, 1)]
    private Vector3 direction = new Vector3(0,1,0);
    [Header("Configuration")]
    [Range(0.01f, 1)]                   // This attribute makes the field underneath into a slider in the editor.
    public float pullDelay = .05f;      // The responsiveness with which the lever matches the controller's position.
    public float Accuracy = 0.01f;
    public float BreakDistance = .4f;   // Distance in worldspace units at which the user is forced to let go of the lever.
    [Header("Spring")]
    public bool isSpring = false;      // If set, the handle returns to a resting position
    public float SpringDelay = .05f;    // The responsiveness with which the lever returns to its restingValue.
    public float RestingXValue = 0f;
    [Header("Haptics")]
    public float dragHaptics = .5f;     // Multiplier for the haptic feedback when dragging. 
    public float hoverHaptics = 1f;     // Multiplier for the haptic feedback when hovering. 

    public float angleToAdd = 0;
    public float angleToStop = Mathf.Infinity;

    private Transform door;

    private float Value;

    private void OnValidate() {

    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
        door = transform.parent.parent;
        direction = direction.normalized;
    }
	
	// Update is called once per frame
	void Update () {
		if (attachedController != null && !locked){
            Vector3 controllerPos = attachedController.transform.position;
            float distanceToHandle = Vector3.Distance(controllerPos, transform.position);

            if (distanceToHandle > BreakDistance)
            {
                attachedController.input.TriggerHapticPulse(2999);
                DetatchController(Vector3.zero);
                return;
            }
            Vector3 localPos;
            if (type == 0) {
                localPos = door.parent.InverseTransformPoint(controllerPos);
            }else {
                localPos = door.InverseTransformPoint(controllerPos);
            }

            float yAngle = ((Mathf.Atan2(localPos.x, localPos.z) * Mathf.Rad2Deg) + angleToAdd);
            print(yAngle);
            if (yAngle > angleToStop) return;
            float yTransformAngle = Mathf.Clamp(yAngle, -rotateLimit, 0);
            door.localEulerAngles = new Vector3(door.localEulerAngles.x, yTransformAngle, door.localEulerAngles.z);
            if (Mathf.Abs(yAngle) > Accuracy)
            {
                float hapticStrength = 2999 * (Mathf.Abs(yAngle) + .1f) * dragHaptics;
                hapticStrength = Mathf.Clamp(hapticStrength, 0, 2999);
                attachedController.input.TriggerHapticPulse((ushort)hapticStrength);
            }
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == key) {
            locked = false;
        }
    }
}