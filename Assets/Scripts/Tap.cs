using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : Interactable {

    public bool Hot = true;
    public GameObject Water;

    public bool isOn;

    // Use this for initialization
    protected override void Start() {
        base.Start();
        isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getIsOn()
    {
        return isOn;
    }

    protected override void OnBeginInteraction()
    {
        base.OnBeginInteraction();
        if (Water.activeInHierarchy && isOn)
        {
            Water.SetActive(false);
            isOn = false;
        } else if (!Water.activeInHierarchy)
        {
            Water.SetActive(true);
            isOn = true;
        }
    }
}
