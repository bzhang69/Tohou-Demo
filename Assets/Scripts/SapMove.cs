using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapMove : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;
    //private float inputH;
    //private float inputV;
    private int direction = 0;
    public float moveSpeed = 1;
    private float curVelocity = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        /*inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH",inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 20f * Time.deltaTime;*/

        float moveX = 0;
        float moveZ = 0;
        anim.SetBool("Walking", true);
        if (Input.anyKey)
        {
            if (Input.GetKey("w"))
            {
                moveZ += 0.1f;

                if (Input.GetKey("a"))
                {
                    moveZ -= 0.07f;
                    moveX -= 0.07f;
                    direction = -45;
                }
                else if (Input.GetKey("d"))
                {
                    moveZ -= 0.07f;
                    moveX += 0.07f;
                    direction = 45;
                }
                else
                {
                    direction = 0;
                }
            }
            else if (Input.GetKey("s"))
            {
                moveZ -= 0.1f;

                if (Input.GetKey("a"))
                {
                    moveZ += 0.07f;
                    moveX -= 0.07f;
                    direction = -135;
                }
                else if (Input.GetKey("d"))
                {
                    moveZ += 0.07f;
                    moveX += 0.07f;
                    direction = 135;
                }
                else
                {
                    direction = -180;
                }
            }
            else if (Input.GetKey("a"))
            {
                moveX -= 0.1f;
                direction = -90;
            }
            else if (Input.GetKey("d"))
            {
                moveX += 0.1f;
                direction = 90;
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        /*if (inputH > 0.1)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);

        }
        if (inputH < -0.1)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (inputV > 0.1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (inputV < -0.1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }*/
        rb.position = new Vector3(rb.position.x + moveX, 0f, rb.position.z + moveZ);
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
}
