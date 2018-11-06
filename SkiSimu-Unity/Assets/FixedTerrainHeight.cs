using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTerrainHeight : MonoBehaviour {
    private float initialHeight;
    public float roomHeight;
    private float deltaHeight;
	// Use this for initialization
	void Start () {
        initialHeight= Terrain.activeTerrain.SampleHeight(transform.position);
        deltaHeight = roomHeight/2f - 0.35f;
    }

    // Update is called once per frame

    void LateUpdate()
    {
        Vector3 pos = transform.position;  //Set height to terrain height + half of cube height
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position) - initialHeight + deltaHeight;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0); // Set Z axis rotation to Zero
    }
    
}

