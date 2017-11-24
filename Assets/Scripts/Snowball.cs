using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

    public GameObject createKey = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fire")) {
            gameObject.transform.localScale -= new Vector3(0.00003f, 0.00003f, 0.00003f);
            if (gameObject.transform.localScale.x <= 0.06) {
                GetComponent<Interactable>().DetatchController(Vector3.zero);
                Destroy(this.gameObject);
                if (createKey != null) {
                    createKey.transform.position = transform.position;
                    createKey.SetActive(true);
                }
            }
        }
    }
}
