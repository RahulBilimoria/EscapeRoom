using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable {

    // Use this for initialization
    private bool lightOn;
    private int lightObjects;
    public GameObject[] lightObject;
    private Light pointLight;
    protected override void Start () {
        base.Start();
        lightObjects = lightObject.Length;
        lightOn = false;
        TurnLights(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    protected override void OnBeginInteraction() {
        base.OnBeginInteraction();
        lightOn = !lightOn;
        TurnLights(lightOn);
    }

    private void TurnLights(bool on) {
        for (int x = 0; x < lightObjects; x++) {
            lightObject[x].GetComponent<Light>().enabled = on;
        }
    }
}
