using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour {

    public int obj;
    private StoolsPuzzle puzzle;

	// Use this for initialization
	void Start () {
        puzzle = transform.parent.GetComponent<StoolsPuzzle>();
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Knife") puzzle.HitObject(obj);
    }
}
