using NuitrackSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBody : MonoBehaviour {
    string message = "";

    public nuitrack.JointType[] jointsToTrack;
    GameObject[] jointGOList;
    public GameObject jointPrefab;

    void Start() {
        jointGOList = new GameObject[jointsToTrack.Length];

        for (int q = 0; q < jointsToTrack.Length; q++) {
            jointGOList[q] = Instantiate(jointPrefab);
            jointGOList[q].transform.SetParent(transform);
        }
        message = "Skeleton created";
    }

    void Update() {
        if (NuitrackManager.Users.Current != null && NuitrackManager.Users.Current.Skeleton != null) {
            message = "Skeleton found";

            for (int q = 0; q < jointsToTrack.Length; q++) {
                UserData.SkeletonData.Joint joint = NuitrackManager.Users.Current.Skeleton.GetJoint(jointsToTrack[q]);
                jointGOList[q].transform.localPosition = joint.Position;
            }
        } else {
            message = "Skeleton not found";
        }
    }

    // Display the message on the screen
    void OnGUI() {
        GUI.color = Color.red;
        GUI.skin.label.fontSize = 50;
        GUILayout.Label(message);
    }
}
