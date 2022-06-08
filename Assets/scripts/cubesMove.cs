using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesMove : MonoBehaviour {
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
        v.y = delta * Mathf.Sin((Time.time / 2) * speed);
        transform.position = v;
    }
}
