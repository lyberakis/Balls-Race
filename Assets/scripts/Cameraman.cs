using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraman : MonoBehaviour {
    public GameObject MyBall;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - MyBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (MyBall != null)
        {
            transform.position = MyBall.transform.position + offset;
        }
	}
}
