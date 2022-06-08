using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 direction;
    public float speed;
    public Text posText;
    public Text pointText;
    public Transform Player; 
    public Transform[] Target;
    private bool isTrigged;
    private float timeCount=0;
    private int points=0;

    void Start () {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 movement = new Vector3(speed, 0.0f, 0);
        rb.AddForce(movement);

        timeCount += Time.deltaTime;
        if (isTrigged == true && timeCount >= 3)
        {
            rb.AddForce(-500, 0.0f, 0);
            isTrigged = false;
        }


        int frontBalls = 0;
        for (int i = 0; i < Target.Length; i++)
        {
            if (Target[i] !=null)
            {
                if (Target[i].position.x > Player.position.x)
                {
                    frontBalls++;
                }
            }
        }
        pointText.text = points.ToString();
        if(frontBalls==0)
             posText.text = (frontBalls + 1).ToString()+"st";
        else if(frontBalls==1)
            posText.text = (frontBalls + 1).ToString() + "nd";
        else if(frontBalls==2)
            posText.text = (frontBalls + 1).ToString() + "rd";
        else
            posText.text = (frontBalls + 1).ToString() + "th";
    }

        void FixedUpdate()
    {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(0, 0.0f, -moveHorizontal);
            
            rb.AddForce(movement*25);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Destroy(this);
            SceneManager.LoadSceneAsync("start menu");
        }

        if (other.gameObject.CompareTag("Boost") && isTrigged==false)
        {
            timeCount = 0;
            isTrigged = true;
            Vector3 movement = new Vector3(1000, 0.0f, 0);
            rb.AddForce(movement);
        }

        if (other.gameObject.CompareTag("Point"))
        {
            points++;
        }
    }
}
