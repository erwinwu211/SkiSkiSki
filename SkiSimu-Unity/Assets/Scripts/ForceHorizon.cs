using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHorizon : MonoBehaviour {
    public Rigidbody rb;
    Vector3 vector;
    Vector3 point;
    private Vector3 pre_dir;
    Vector3 rotationLast;
    Transform fp;
    public float fmagnitude = 1.0f;

	// Use this for initialization
	void Start () {
        //Time.timeScale = 0.5f;
        vector = new Vector3(1.0f, 0.0f, 0.0f);
        fp = GameObject.Find("ForcePoint").transform;
        point = fp.position;
        pre_dir = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        rb.maxAngularVelocity = 200f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        vector = transform.right * fmagnitude;
        point =  fp.position;
        rb.AddForceAtPosition(vector, point);
        print(rb.GetPointVelocity(fp.position).magnitude);
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.TransformPoint(rb.centerOfMass), 0.05f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(point, 0.05f);
    }
}
