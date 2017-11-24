using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class KeyHole : MonoBehaviour {

    public int KeyNumber;
    public GameObject Key = null;

    private LockedDoor MasterLock;
    private bool unlocked;

	// Use this for initialization
	void Start () {
        unlocked = false;
        MasterLock = transform.parent.gameObject.GetComponent<LockedDoor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (!unlocked && other.gameObject == Key) {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.layer = LayerMask.NameToLayer("Default");
            other.GetComponent<Interactable>().DetatchController(Vector3.zero);
            other.transform.position = transform.position;
            other.transform.localEulerAngles = Vector3.zero;
            gameObject.AddComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
            unlocked = true;
            MasterLock.unlockedKey(KeyNumber, unlocked);
        }
    }
}
