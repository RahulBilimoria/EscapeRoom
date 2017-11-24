using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoolsPuzzle : MonoBehaviour {

    public GameObject Opening;
    public GameObject Key;
    private bool solved = false;
    private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HitObject(int obj)
    {
        if (!solved) {
            if (counter == obj) {
                if (counter == 2) {
                    solved = true;
                    giveKey();
                    return;
                }
                counter++;
            } else counter = 0;
        }
    }

    private void giveKey()
    {
        Key.transform.position = Opening.transform.position;
        Key.SetActive(true);
    }
}
