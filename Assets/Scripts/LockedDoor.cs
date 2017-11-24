using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

    public int NumberOfKeys = 1;
    public bool winGame = false;
    public GameObject door;
    private bool unlocked;
    private bool[] Keys;

    // Use this for initialization
    void Start () {
        unlocked = false;
        Keys = new bool[NumberOfKeys];
        for (int x = 0; x < NumberOfKeys; x++) {
            Keys[x] = false;
        }
    }

    void Update() {
        if (winGame && unlocked) {
            door.transform.localScale += new Vector3(-0.001f, -0.001f, 0);
            if (door.transform.localScale.x < 0) {
                Destroy(door);
            }
        }
    }

    public void unlockedKey(int key, bool locked) {
        Keys[key] = locked;
        for (int x = 0; x < NumberOfKeys; x++) {
            if (!Keys[x]) return;
        }
        unlockDoor();
    }

    private void unlockDoor() {
        unlocked = true;
    }

    public bool getUnlocked() {
        return unlocked;
    }
}
