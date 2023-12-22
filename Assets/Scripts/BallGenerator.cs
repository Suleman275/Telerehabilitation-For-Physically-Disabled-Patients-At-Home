using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {
    [SerializeField] private int numberOfBalls;
    [SerializeField] private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < numberOfBalls; i++) {
            Instantiate(ballPrefab, new Vector3(-5,5,0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
