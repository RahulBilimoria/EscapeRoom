using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour {

    public GameObject created;

    public string Item1;
    public string Item2;
    public string Item3;
    public string Item4;

    private bool haveItem1 = false;
    private bool haveItem2 = false;
    private bool haveItem3 = false;
    private bool haveItem4 = false;

    private GameObject Item1Object;
    private GameObject Item2Object;
    private GameObject Item3Object;
    private GameObject Item4Object;


    private bool onStove = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (haveItem1 && haveItem2 && haveItem3 && haveItem4 && onStove) {
            Destroy(Item1Object);
            Destroy(Item2Object);
            Destroy(Item3Object);
            Destroy(Item4Object);
            created = Instantiate(created);
            created.transform.position = transform.position;
            haveItem1 = false;
            haveItem2 = false;
            haveItem3 = false;
            haveItem4 = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fire"))
        {
            onStove = true;
        }
        if (other.name == Item1) {
            haveItem1 = true;
            Item1Object = other.gameObject;
        } else if (other.name == Item2) {
            haveItem2 = true;
            Item2Object = other.gameObject;
        }
        else if (other.name == Item3) {
            haveItem3 = true;
            Item3Object = other.gameObject;
        }
        else if (other.name == Item4) {
            haveItem4 = true;
            Item4Object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fire"))
        {
            onStove = false;
        }
        if (other.name == Item1)
        {
            haveItem1 = false;
            Item1Object = null;
        }
        else if (other.name == Item2)
        {
            haveItem2 = false;
            Item2Object = null;
        }
        else if (other.name == Item3)
        {
            haveItem3 = false;
            Item3Object = null;
        }
        else if (other.name == Item4)
        {
            haveItem4 = false;
            Item4Object = null;
        }
    }
}
