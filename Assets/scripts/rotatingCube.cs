using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingCube : MonoBehaviour {
    private Vector3 startPos;
    public float delta = 1.0f;
    public float speed = 1.0f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.z = delta * Mathf.Sin((Time.time / 2) * speed)+80;
        transform.position = v;
        transform.Rotate(Vector3.up, 100.0f * Time.deltaTime);
    }
}
