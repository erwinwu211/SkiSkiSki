using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour {
    public GameObject room;
    private Quaternion cameraRotation;
    public float height;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(500, 50, 100, 50), "Reset Camera"))
        {
            Reset();
        }
    }
    private void Reset()
    {
        cameraRotation= Quaternion.FromToRotation(GameObject.Find("Camera").transform.forward, room.transform.forward);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position =new Vector3( room.transform.position.x, room.transform.position.y+height, room.transform.position.z);
        transform.rotation = Quaternion.Euler(room.transform.rotation.eulerAngles + cameraRotation.eulerAngles);

        //transform.rotation = Quaternion.Euler(room.transform.forward + cameraRotation.eulerAngles);
        //print(Quaternion.Euler(room.transform.rotation.eulerAngles));
	}
}
