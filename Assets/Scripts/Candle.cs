using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

    private bool onFire;
    private GameObject fire;

	// Use this for initialization
	void Start () {
        onFire = false;
        fire = transform.GetChild(0).gameObject;
        fire.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!onFire && other.gameObject.layer == LayerMask.NameToLayer("Fire"))
        {
            fire.SetActive(true);
            this.gameObject.layer = 12;
            onFire = !onFire;
        }
        else if (onFire && other.gameObject.layer == LayerMask.NameToLayer("WaterLayer"))
        {
            fire.SetActive(false);
            this.gameObject.layer = 0;
            onFire = !onFire;
        }
    }
}
