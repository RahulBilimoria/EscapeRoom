using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour {

    private SteamVR_Controller.Device input;

    private Vector3 point;

    private bool nav;
    private bool move;

    // Use this for initialization
    void Start () {
        var trackedObj = this.GetComponent<SteamVR_TrackedObject>();
        input = SteamVR_Controller.Input((int)trackedObj.index);

        nav = false;
        move = false;
        point = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if (input.GetTouch(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
            if (!move)
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, transform.position + transform.forward * 10f);
                RaycastHit collide;
                bool hit = Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out collide, 1000);
                if (hit && collide.collider.tag.Equals("Floor"))
                {
                    GetComponent<LineRenderer>().SetPosition(1, collide.point);
                    if (input.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                    {
                        move = true;
                        point = collide.point;
                        SteamVR_Fade.View(Color.black, 1f);
                        Invoke("movePlayer", 2f);
                    }
                }
            }
        }
        else {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
    }

    void movePlayer()
    {
        Vector3 head = gameObject.transform.parent.GetChild(2).localPosition;
        head.y = 0;
        point.y = gameObject.transform.parent.position.y;
        gameObject.transform.parent.position = point + head;
        point = Vector3.zero;
        SteamVR_Fade.View(new Color(0, 0, 0, 0), 3f);
        move = false;
    }
}
