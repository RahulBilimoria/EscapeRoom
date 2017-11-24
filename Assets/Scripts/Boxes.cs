using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour {

    public GameObject key = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Crowbar")
        {
            if (key != null)
            {
                key.transform.position = transform.position;
                key.SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
