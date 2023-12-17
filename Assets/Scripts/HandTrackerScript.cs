using UnityEngine;
using NuitrackSDK;

public class HandTrackerScript : MonoBehaviour {
    [SerializeField] private bool visulaiseHands;
    [SerializeField] private GameObject handPrefab;

    private GameObject leftHandGO;
    private GameObject rightHandGO;

    UserData.SkeletonData.Joint leftHandJoint;
    UserData.SkeletonData.Joint rightHandJoint;

    // Start is called before the first frame update
    void Start()
    {
        if (visulaiseHands) {
            leftHandGO = Instantiate(handPrefab);
            rightHandGO = Instantiate(handPrefab);

            leftHandGO.transform.SetParent(transform);
            rightHandGO.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update() {
        if (NuitrackManager.Users.Current != null && NuitrackManager.Users.Current.Skeleton != null) {

            // Track left and right hand positions
            leftHandJoint = NuitrackManager.Users.Current.Skeleton.GetJoint(nuitrack.JointType.LeftHand);
            rightHandJoint = NuitrackManager.Users.Current.Skeleton.GetJoint(nuitrack.JointType.RightHand);

            // Log the positions of left and right hands
            //Debug.Log("Left Hand Position: " + leftHandJoint.Position);
            //Debug.Log("Right Hand Position: " + rightHandJoint.Position);

            //Upate the hand game object positions on x and y axis
            if (visulaiseHands) {
                leftHandGO.transform.localPosition = new Vector3(leftHandJoint.Position.x, leftHandJoint.Position.y, 0);
                rightHandGO.transform.localPosition = new Vector3(rightHandJoint.Position.x, rightHandJoint.Position.y, 0);
            }
        }
        else {
            Debug.Log("Body not in View");
        }
    }
}
