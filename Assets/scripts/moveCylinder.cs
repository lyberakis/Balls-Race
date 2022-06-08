using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCylinder : MonoBehaviour {
    private Vector3 startPos;
    public float delta = 1.0f; 
    public float speed = 1.0f;

    void Start () {
        startPos = transform.position;
	}
	
	void Update () {
        Vector3 v = startPos;
        v.z =delta * Mathf.Sin((Time.time/2) * speed)+80;
        transform.position = v;
    }
}
