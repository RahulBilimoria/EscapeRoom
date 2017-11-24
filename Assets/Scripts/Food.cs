using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Interactable {

    private string Name;

    // Use this for initialization
    protected override void Start() {
        base.Start();
        Name = this.name;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
