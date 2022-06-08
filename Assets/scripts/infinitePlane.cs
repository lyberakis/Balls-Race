using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class infinitePlane : MonoBehaviour {
    public GameObject plane;
    private Transform playerTrans;
    private float x=0.0f;
    private float planeLength = 300.0f;
    private List<GameObject> existingPlanes;
	// Use this for initialization
	void Start () {
        existingPlanes = new List<GameObject>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < planeLength/10; i++)
        {
            CreatePlane();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTrans != null)
        {
            if (playerTrans.transform.position.x + planeLength > x - 15 * planeLength)
            {
                CreatePlane();
                DeletePlane();
            }
        }
	}

    void CreatePlane()
    {
        GameObject newPlane;
        newPlane = Instantiate(plane) as GameObject;
        newPlane.transform.SetParent(transform);
        newPlane.transform.position = Vector3.right * x;
        x = x + planeLength;
        existingPlanes.Add(newPlane);
    }

    void DeletePlane()
    {
        Destroy(existingPlanes[0]);
        existingPlanes.RemoveAt(0);
    }
}
