using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoom : Interactable {

    private bool canEscape;

	// Use this for initialization
	protected override void Start () {
        canEscape = false;
	}

    // Update is called once per frame
    protected override void OnBeginInteraction() {
        base.OnBeginInteraction();
        if (canEscape) {
            DetatchController(Vector3.zero);
            //WIN SCREEN HERE
        }
    }
}
