using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBindedByTerrain: MonoBehaviour {
    public float speed = 10f;

    Vector3 forwardDirection;
    Vector3 forwardMove;
    Vector3 currentPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        forwardDirection = transform.forward;
        forwardMove = forwardDirection * speed;
        Vector3 targetPos = transform.position + forwardMove;
        targetPos.y = Terrain.activeTerrain.SampleHeight(targetPos);
        transform.position = targetPos;
	}
}
