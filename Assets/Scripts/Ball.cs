using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private HandSelection targetHand;

    private GameObject hand;

    private enum HandSelection {
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start() {
        if (targetHand == HandSelection.Left) {
            hand = HandTrackerScript.Instance.leftHandGO;
        }
        else if (targetHand == HandSelection.Right) {
            hand = HandTrackerScript.Instance.rightHandGO;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
