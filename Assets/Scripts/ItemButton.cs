using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour {

    public GameObject[] obj = new GameObject[5];

    private int count = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (count < 5 && collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            obj[count].SetActive(true);
            count++;
        }
    }
}
