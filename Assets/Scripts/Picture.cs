using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour {

    public int type;

    public GameObject createKey;

    public GameObject Nail1;
    public GameObject Nail2;
    public GameObject Nail3;
    public GameObject Nail4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (type == 1) {
            if (!Nail1.activeInHierarchy && !Nail2.activeInHierarchy && !Nail3.activeInHierarchy && !Nail4.activeInHierarchy) {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Interactables") && type == 0){
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (collision.collider.tag == "Floor" && type == 1) {
            createKey.SetActive(true);
        }
    }
}
