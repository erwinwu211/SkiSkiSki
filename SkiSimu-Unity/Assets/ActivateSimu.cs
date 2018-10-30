using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSimu : MonoBehaviour {
    float timeCount;
    public GameObject simuObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;
        if (timeCount >= 1)
        {
            simuObject.SetActive(true);
        }
	}
}
