using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSapp : MonoBehaviour {

    private Animator anim;
    private int direction = 0;
    public float moveSpeed = 1;
    private int walkHash = Animator.StringToHash("Walking");
    private int runHash = Animator.StringToHash("Running");
    private int dashHash = Animator.StringToHash("Dashing");
    private int idleHash = Animator.StringToHash("Idling");
    private bool isDashing = false;
    private int dashTime = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Walking()
    {
        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey("w"))
        {
            moveZ += 0.1f;

            if (Input.GetKey("a"))
            {
                moveZ -= 0.03f;
                moveX -= 0.07f;
                direction = -45;
            }
            else if (Input.GetKey("d"))
            {
                moveZ -= 0.03f;
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
            anim.SetBool(walkHash, true);
            moveZ -= 0.1f;

            if (Input.GetKey("a"))
            {
                moveZ += 0.03f;
                moveX -= 0.07f;
                direction = -135;
            }
            else if (Input.GetKey("d"))
            {
                moveZ += 0.03f;
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

        transform.position = new Vector3(transform.position.x + moveX, 0f, transform.position.z + moveZ);
        transform.eulerAngles = new Vector3(0, direction, 0);
}

    void Running()
    {
        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey("w"))
        {
            moveZ += 0.1f;

            if (Input.GetKey("a"))
            {
                moveZ -= 0.03f;
                moveX -= 0.07f;
                direction = -45;
            }
            else if (Input.GetKey("d"))
            {
                moveZ -= 0.03f;
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
            anim.SetBool(walkHash, true);
            moveZ -= 0.1f;

            if (Input.GetKey("a"))
            {
                moveZ += 0.03f;
                moveX -= 0.07f;
                direction = -135;
            }
            else if (Input.GetKey("d"))
            {
                moveZ += 0.03f;
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

        transform.position = new Vector3(transform.position.x + moveX*2, 0f, transform.position.z + moveZ*2);
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

    void Dashing()
    {
        isDashing = true;
        float dashDir = transform.eulerAngles.y;

        if (dashDir == 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z + 0.2f);
        }
        else if (dashDir == 180f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z - 0.2f);
        }
        else if (dashDir == 90f)
        {
            transform.position = new Vector3(transform.position.x + 0.2f, 0f, transform.position.z);
        }
        else if (dashDir == 270f)
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 0f, transform.position.z);
        }
        else if (dashDir == 135f)
        {
            transform.position = new Vector3(transform.position.x + 0.2f, 0f, transform.position.z - 0.2f);
        }
        else if (dashDir == 225f)
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 0f, transform.position.z - 0.2f);
        }
        else if (dashDir == 315f)
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 0f, transform.position.z + 0.2f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 0.2f, 0f, transform.position.z + 0.2f);
        }
    }

// Update is called once per frame
void Update()
{
        anim.SetBool(idleHash, true);
        anim.SetBool(walkHash, false);
        anim.SetBool(runHash, false);
        
        if(Input.GetKeyDown(KeyCode.Space) || isDashing)
        {
            anim.SetBool(dashHash, true);
            Dashing();

            dashTime++;
            if(dashTime > 20)
            {
                dashTime = 0;
                isDashing = false;
                anim.SetBool(dashHash, false);
            }
        }
        else if(Input.GetKey("w")|| Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            anim.SetBool(idleHash, false);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool(runHash, true);
                Running();
            }
            else
            {
                anim.SetBool(walkHash, true);
                Walking();
            }
        }
        
}
}
