using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracker : MonoBehaviour {
    public Transform Mother;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Mother.transform.position;
	}
}
