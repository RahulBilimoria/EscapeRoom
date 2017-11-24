using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

    private bool unlocked;
    private LockedDoor thisLock;

	// Use this for initialization
	void Start () {
        unlocked = false;
        thisLock = transform.GetChild(1).GetComponent<LockedDoor>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!unlocked && thisLock.getUnlocked()) {
            unlocked = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
