using UnityEngine;
using NuitrackSDK;

public class HandTrackerScript : MonoBehaviour {
    
    UserData.SkeletonData.Joint leftHandJoint;
    UserData.SkeletonData.Joint rightHandJoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (NuitrackManager.Users.Current != null && NuitrackManager.Users.Current.Skeleton != null) {

            // Track left and right hand positions
            leftHandJoint = NuitrackManager.Users.Current.Skeleton.GetJoint(nuitrack.JointType.LeftHand);
            rightHandJoint = NuitrackManager.Users.Current.Skeleton.GetJoint(nuitrack.JointType.RightHand);

            // Log the positions of left and right hands
            Debug.Log("Left Hand Position: " + leftHandJoint.Position);
            Debug.Log("Right Hand Position: " + rightHandJoint.Position);
        }
        else {
            Debug.Log("Hands not in View");
        }
    }
}
