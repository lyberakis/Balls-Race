using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentsMove : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 direction;
    public float speed;
    private bool isTrigged;
    private float timeCount=0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(speed, 0.0f, 0);
        rb.AddForce(movement);

        timeCount += Time.deltaTime;
        if(isTrigged==true && timeCount >= 3)
        {
            rb.AddForce(-500, 0.0f, 0);
            isTrigged = false;
        }

        RaycastHit hit;
        var left = (transform.forward + transform.right + transform.right).normalized;
        var right = (transform.right - transform.forward + transform.right).normalized;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Finish")
            {
                rb.AddForce(0, 0.0f, 100);
            }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(left), out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Finish")
            {
                rb.AddForce(0, 0.0f, -100);
            }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(right), out hit, Mathf.Infinity))
         {
            if (hit.collider.tag == "Finish")
            {
                rb.AddForce(0, 0.0f, 100);
            }
        }
        else
        {
            rb.AddForce(0, 0.0f, -100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Destroy(this);
        }

        if (other.gameObject.CompareTag("Boost") && isTrigged==false)
        {
            isTrigged = true;
            timeCount = 0;
            Vector3 movement = new Vector3(500, 0.0f, 0);
            rb.AddForce(movement);
        }
    }
}
