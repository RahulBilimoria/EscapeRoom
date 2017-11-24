using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    public GameObject Tap;

    private Tap Cold;

	// Use this for initialization
	void Start () {
        Cold = Tap.GetComponent<Tap>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Cold.isOn)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Fire"))
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                //Show Canvas with the secret code
            }
        }
    }
}
