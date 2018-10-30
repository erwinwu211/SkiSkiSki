using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode()]
public class OperateAnimator : MonoBehaviour {
    public GameObject Human;
    public int AnimationSpeed = 1;

    private Animator m_animator;
    private GUIStyle style;
    private bool openMenu = false;
    private int selGridInt = 0;
    public string[] selStrings;
    private Vector2 scrollPosition;


    // Use this for initialization
    void Start () {
        m_animator = Human.GetComponent<Animator>();
        style = new GUIStyle();
        style.fontSize = 10;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (openMenu)
        {
            // change animation Speed
            AnimationSpeed = (int)GUI.HorizontalSlider(new Rect(45, 25, 150, 30), AnimationSpeed, 0, 10);
            GUI.Label(new Rect(200, 25, 220, 30), AnimationSpeed.ToString() + "x", style);
            m_animator.speed = AnimationSpeed;

            // select motion
            GUILayout.BeginArea(new Rect(260, 50, 220, 200));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(200));
            GUILayout.BeginVertical("Box");
            selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 1);
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.EndArea();
            if (GUI.Button(new Rect(160, 50, 100, 50), "SetMotion"))
            {
                m_animator.SetInteger("Motion", selGridInt + 1);
            }


            if (GUI.Button(new Rect(50, 50, 100, 50), "Close"))
            {
                openMenu = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(50, 50, 100, 50), "MENU"))
            {
                openMenu = true;
            }
        }
    }
}
