using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjects : MonoBehaviour {
    public GameObject[] obstacles;
	// Use this for initialization
	void Start () {
       int randObstacle = Random.Range(0, 4);
       Instantiate(obstacles[randObstacle], transform);
    }
	
}
