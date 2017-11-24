using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBasket : MonoBehaviour {

    public GameObject Key;

    public string FoodName1;
    public string FoodName2;
    public string FoodName3;

    private GameObject Item1, Item2, Item3;

    private bool key1, key2, key3;

    private bool completed;
    private bool givenItem;
    private bool animationComplete;

	// Use this for initialization
	void Start () {
        key1 = false;
        key2 = false;
        key3 = false;
        completed = false;
        givenItem = false;
        animationComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!animationComplete) {
            if (completed && !givenItem) {
                if (transform.parent.position.z > -5.2) {
                    transform.parent.Translate(new Vector3(0, 0, -0.001f));
                } else {
                    givenItem = true;
                }
            }
            if (completed && givenItem) {
                if (transform.parent.position.z < -4.75) {
                    transform.parent.Translate(new Vector3(0, 0, 0.001f));
                }
                else {
                    Instantiate(Key).transform.position = transform.parent.position;
                    transform.parent.GetChild(0).gameObject.SetActive(false);
                    Key.transform.position = transform.position;
                    Key.SetActive(true);
                    animationComplete = true;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (!completed) {
            if (other.gameObject.tag == FoodName1) {
                key1 = true;
                Item1 = other.gameObject;
                other.GetComponent<Interactable>().DetatchController(Vector3.zero);
            } else if (other.gameObject.tag == FoodName2) {
                key2 = true;
                Item2 = other.gameObject;
                other.GetComponent<Interactable>().DetatchController(Vector3.zero);
            } else if (other.gameObject.tag == FoodName3) {
                key3 = true;
                Item3 = other.gameObject;
                other.GetComponent<Interactable>().DetatchController(Vector3.zero);
            }
            if (key1 && key2 && key3) {
                completed = true;
                getKey();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == FoodName1) {
            key1 = false;
        }
        else if (other.gameObject.tag == FoodName2) {
            key2 = false;
        }
        else if (other.gameObject.tag == FoodName3) {
            key3 = false;
        }
    }

    private void getKey() {
        Destroy(Item1);
        Destroy(Item2);
        Destroy(Item3);
        transform.parent.GetChild(0).gameObject.SetActive(true);
    }
}
