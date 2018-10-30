using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : MonoBehaviour {
    public float speed;
    public GameObject Route;
    public bool loop;

    Vector3 delta;
    float timeCount = 0.0f;
    int current;
    bool startRotation;
    float rotateSpeed;
    float rotateTime;
    Vector3 Lookatposition;
    Quaternion rotateAngle;
    Quaternion rotation;
    Vector3 nextDirection;
    Vector3 presentDirection;

    private List<Transform> target = new List<Transform>();

    void Start () {
        current = 0;
        startRotation = true;
        Transform[] pathTransforms = Route.GetComponentsInChildren<Transform>();

        target = new List<Transform>();
        for (int i = 1; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                target.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float Distance = Vector3.Distance(transform.position, target[current].position);
        if (Distance < 2f)
        {
            Rotate(Distance);
        }
        else
        {
            startRotation = true;
        }
        Move();
        if (Vector3.Distance(transform.position, target[current].position) < 1f)
        {
            current += 1;
            if (current >= target.Count && loop)
            {
                current = 0;
            }
        }
    }

    void Rotate(float Distance)
    {
        if (startRotation)
        {
            Lookatposition = target[current].position;
            rotateAngle = Quaternion.FromToRotation(nextDirection, presentDirection);
            rotateTime = Distance / speed;
            startRotation = false;
        }
        if (current + 1 < target.Count)
        {
            delta = (target[current + 1].position - target[current].position) * 0.02f;
        }
        else
        {
            delta = (target[0].position - target[current].position) * 0.02f;
        }
        Lookatposition = Lookatposition + delta;
        transform.LookAt(Lookatposition);
    }

    void Move ()
    { 
        Vector3 movement = target[current].position - transform.position;
        movement = movement.normalized * speed * Time.deltaTime;
        transform.position = transform.position + movement;
    }
}
