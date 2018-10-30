using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followCube : MonoBehaviour {
    public float height;
    public string cubeName;
    private GameObject cube;
    private GameObject[] goArray;
    //private Animator m_Animator;

	// Use this for initialization
	void Start () {
        //m_Animator = gameObject.GetComponent<Animator>();
        goArray = SceneManager.GetSceneByName("Test").GetRootGameObjects();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].name == cubeName)
                cube = goArray[i];
        }
        //m_Animator.speed = 2.0f;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3 (0,-height,0)+cube.transform.position;
        transform.rotation = cube.transform.rotation;
	}
}
