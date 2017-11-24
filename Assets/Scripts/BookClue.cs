using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClue : MonoBehaviour {

    public GameObject clue;

    private bool revealed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!revealed && collision.gameObject.tag == "Sharp") {
            revealed = true;
            clue.transform.position = transform.position;
            clue.SetActive(true);
        }
    }
}
