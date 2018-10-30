using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSkis : MonoBehaviour {

    private List<Transform> transforms = new List<Transform>();
    private List<Transform> trackingTransforms = new List<Transform>();
    
    void Start () {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            transforms.Add(t);
        }

        // 別シーンのTrackingSkisオブジェクトを持ってきて、その子であるスキー板のtransformを取得
        GameObject[] tmp = SceneManager.GetSceneByName("VRTracking").GetRootGameObjects();
        GameObject TrackingSkis;
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i].name == "TrackingSkis")
            {
                TrackingSkis = tmp[i];
                foreach (Transform t in TrackingSkis.GetComponentInChildren<Transform>())
                {
                    trackingTransforms.Add(t);
                }
            }  
        }
    }

    void Update()
    {
        // Trackingしているスキーのローカルな位置・回転を子のスキー達に反映させる。
        for (int i = 0; i < 2; i++)
        {
            Vector3 trackingPosition = trackingTransforms[i].localPosition;
            Quaternion trackingRotation = trackingTransforms[i].rotation;
            transforms[i].localPosition = new Vector3(trackingPosition.x,0f,trackingPosition.z);
            transforms[i].localRotation = trackingRotation;
        }
    }
}
