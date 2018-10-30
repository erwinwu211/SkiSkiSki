using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSkisMovement : MonoBehaviour {
    public Transform rightFoot;
    public Transform leftFoot;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3((rightFoot.position.x + leftFoot.position.x) / 2,
                                     (rightFoot.position.y + leftFoot.position.y) / 2 ,
                                     (rightFoot.position.z + leftFoot.position.z) / 2);
        this.transform.rotation = leftFoot.rotation;
    }
}
