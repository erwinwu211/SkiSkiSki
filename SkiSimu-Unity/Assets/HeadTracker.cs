using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracker : MonoBehaviour {
    public Transform rightFoot;
    public Transform leftFoot;
    public float height;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3((rightFoot.position.x + leftFoot.position.x) / 2,
                                             (rightFoot.position.y + leftFoot.position.y) / 2 + height,
                                             (rightFoot.position.z + leftFoot.position.z) / 2 );
                                                
	}
}
