using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwitch : Interactable {

    public GameObject FireObject;
    private bool FireOn;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        FireOn = false;
        FireObject.transform.GetChild(0).gameObject.SetActive(FireOn);
        FireObject.transform.GetChild(1).gameObject.SetActive(FireOn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnBeginInteraction() {
        base.OnBeginInteraction();
        FireOn = !FireOn;
        FireObject.transform.GetChild(0).gameObject.SetActive(FireOn);
        FireObject.transform.GetChild(1).gameObject.SetActive(FireOn);
    }
}
