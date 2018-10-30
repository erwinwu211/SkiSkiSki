using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSkiMovement : MonoBehaviour {
    public Transform skis;
    private int initialization;
    private Vector3 prePos;
    private Quaternion preRot;
    // Use this for initialization
    void Start () {
        initialization = 0;   
	}
	
	// Update is called once per frame
	void Update () {
        if (initialization < 20)
        {
            prePos = this.transform.position; //Initialization first Position and rotation
            preRot = this.transform.rotation;
            initialization += 1;
        }
        else
        {
            var latPos = this.transform.position;
            var latRot = this.transform.rotation;
            var diffPos = latPos - prePos; //calculate difference
            skis.transform.position = skis.transform.position + diffPos; // Add the difference of position to skis
            print(diffPos);
            
            prePos = latPos;
            preRot = latRot;
        }
	}
}
