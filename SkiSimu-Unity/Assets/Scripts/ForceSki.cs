using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSki : MonoBehaviour {
    public float magnitude;
    public Rigidbody rb;
    public float rotateSpeed = 1.0f;

    float rot;
    Vector3 direction;
    Vector3 force;
    Vector3 point;
    Vector3 WorldOrigin = new Vector3(0,0,0);


    // Use this for initialization
    void Start () {
        Time.timeScale = 0.2f;
	}

    private void Update()
    {
        Controll(true);
        VisualizeNormalForce(true);
    }


    // 板をキーボードで操作する場合に使う
    private void Controll(bool doit)
    {
        if (doit) {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
            }
        }
    }

    // 板に対する垂直抗力を分析したいときに使う
    private void VisualizeNormalForce(bool doit)
    {
        if (doit)
        {
            // スキー板に対する法線
            Debug.DrawRay(transform.position, this.transform.up, Color.yellow, 0, false);
            // スキー板に対する法線の垂直成分
            Vector3 vertical = Vector3.Project(this.transform.up, new Vector3(0, 1.0f, 0));
            Debug.DrawRay(transform.position, vertical, Color.green, 0, false);
            // スキー板に対する法線の水平成分
            Vector3 horizon = Vector3.Project(this.transform.up, new Vector3(1.0f, 0, 0));
            Debug.DrawRay(transform.position, horizon, Color.red, 0, false);
            // スキー板に対する法線の奥域成分
            Vector3 depth = Vector3.Project(this.transform.up, new Vector3(0, 0, 1.0f));
            Debug.DrawRay(transform.position, depth, Color.blue, 0, false);
        }
    }

    // FixesUpdate can be called more than once per frame
    void FixedUpdate () {
        rot = transform.rotation.eulerAngles.z;
        if (0 <= rot && rot <= 90) ;
        else if (270 <= rot && rot <= 360) rot = rot - 360f;
        else rot = 0;
        direction = new Vector3(this.transform.right.x, 0.0f, this.transform.right.z);
        direction = direction.normalized;
        force = direction * -Mathf.Sin(rot) * magnitude;
        point = transform.position + transform.forward * 0.8f;
        rb.AddForceAtPosition(force, point);
        print(direction);
    }
}