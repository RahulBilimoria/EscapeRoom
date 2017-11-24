using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tub : MonoBehaviour {

    public GameObject Key;
    public GameObject Water;
    private bool unlocked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!unlocked && Water.activeInHierarchy && other.name == "Toaster")
        {
            Key.SetActive(true);
            unlocked = true;
        }   
    }
}
