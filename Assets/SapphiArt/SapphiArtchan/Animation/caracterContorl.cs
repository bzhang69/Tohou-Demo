using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracterContorl : MonoBehaviour {

    private Animator anim;

    private int idleHash = Animator.StringToHash("idle");
    private int runHash = Animator.StringToHash("running");
    private int walkHash = Animator.StringToHash("walk");
    private int dashHash = Animator.StringToHash("dash");
    private int damagedHash = Animator.StringToHash("damage");

    private int backToIdleHash = Animator.StringToHash("backToIdle");

    private float velocity = 0;
    private Vector3 direction = new Vector3(0, 0, 0);

    private AnimatorStateInfo currentState;

    private bool moveRight = false;
    private bool moveUp = false;
    private bool moveLeft = false;
    private bool moveDown = false;
    private bool walk = false;
    private bool dash = false;
    public float dashcd = 1.0f;
    private float lastDashTime;
    private bool dashOnCd = false;
    public Boundary boundary;
    private bool takingDamage = false;

    void Start ()
    {
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	void Update ()
    {
        processDashCD();
        getInput();
        processInput();
        processAnimation();
        move();
	}

    void processAnimation()
    {
        if(!currentState.IsName("dash"))
        {
            if (!currentState.IsName("damage"))
            {
                if (takingDamage)
                {
                    anim.Play(damagedHash);
                    takingDamage = false;
                }
                else
                {
                    if (velocity == 0.2f)
                    {
                        anim.Play(runHash);
                    }
                    else if (velocity == 0.06f)
                    {
                        anim.Play(walkHash);
                    }
                    else if (velocity == 0.5f)
                    {
                        //anim.Play(dashHash);
                        anim.Play(dashHash, -1, 0.4f);
                    }
                    else
                    {
                        anim.Play(idleHash);
                    }
                }
            }
        }
    }

    void move()
    {
        transform.rotation = Quaternion.Euler(direction);
        Vector3 tmp = transform.position;

        //tmp.x += Mathf.Sin(direction.y / 180 * Mathf.PI) * velocity;
        //tmp.z += Mathf.Cos(direction.y / 180 * Mathf.PI) * velocity;

        //Quaternion bounds = boundary.GetBounds();
        tmp.x = Mathf.Clamp(tmp.x + Mathf.Sin(direction.y / 180 * Mathf.PI) * velocity, boundary.xMin, boundary.xMax);
        tmp.z = Mathf.Clamp(tmp.z + Mathf.Cos(direction.y / 180 * Mathf.PI) * velocity, boundary.zMin, boundary.zMax);

        transform.position = tmp;
    }

    void getInput()
    {
        if(Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
            if(Input.GetKey(KeyCode.A))
            {
                moveLeft = true;
            }
            else
            {
                moveLeft = false;
            }
        }

        if(Input.GetKey(KeyCode.W))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
            if(Input.GetKey(KeyCode.S))
            {
                moveDown = true;
            }
            else
            {
                moveDown = false;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            walk = true;
        }
        else
        {
            walk = false;
        }

        currentState = anim.GetCurrentAnimatorStateInfo(0);
        if (!currentState.IsName("dash"))
        {
            dash = false;
        }
        /*if (!currentState.IsName("damage"))
        {
            takingDamage = false;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && !currentState.IsName("dash") && !dashOnCd)
        {
            dash = true;
            dashOnCd = true;
            lastDashTime = Time.time;            
        }

        
    }

    void processInput()
    {
        if (!dash)
        {
            if (moveRight == true)
            {
                if (moveUp == true)
                {
                    direction.y = 45;
                    velocity = 0.2f;
                }
                else if (moveDown == true)
                {
                    direction.y = 135;
                    velocity = 0.2f;
                }
                else
                {
                    direction.y = 90;
                    velocity = 0.2f;
                }
            }
            else if (moveLeft == true)
            {
                if (moveUp == true)
                {
                    direction.y = 315;
                    velocity = 0.2f;
                }
                else if (moveDown == true)
                {
                    direction.y = 225;
                    velocity = 0.2f;
                }
                else
                {
                    direction.y = 270;
                    velocity = 0.2f;
                }
            }
            else
            {
                if (moveUp == true)
                {
                    direction.y = 0;
                    velocity = 0.2f;
                }
                else if (moveDown == true)
                {
                    direction.y = 180;
                    velocity = 0.2f;
                }
                else
                {
                    velocity = 0;
                }
            }

            if (velocity > 0 && walk == true)
            {
                velocity = 0.06f;
            }
        }
        else if(dash == true)
        {
            velocity = 0.5f;
        }
    }

    void processDashCD ()
    {
        if(dashOnCd)
        {
            if(Time.time - lastDashTime>dashcd)
            {
                dashOnCd = false;
            }
        }
    }

    public float getSkillMaxCD(string skillName)
    {
        if(skillName == "dash")
        {
            return dashcd;
        }
        return -1;
    }

    public float getSkillCD(string skillName)
    {
        if (skillName == "dash")
        {
            return Time.time - lastDashTime;
        }
        return -1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shots")
        {
            takingDamage = true;
            if (!currentState.IsName("dash"))
            {
                Destroy(other.gameObject);
            }

        }    
    }

    public bool isDashing()
    {
        if (currentState.IsName("dash"))
        {
            return true;
        }
        return false;
    }
}

