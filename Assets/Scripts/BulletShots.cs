using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShots : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.1f;
    private Vector3 collisionNorm = new Vector3(0f, 0f, 0f);
    private bool isCollision;
    private Vector3 velocity;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        velocity = transform.forward * speed;
        //rb.velocity = transform.forward * speed;   
	}
	
	// Update is called once per frame
	void Update () {
        if(isCollision)
        {
            //rb.velocity = Vector3.Reflect(rb.velocity, collisionNorm);
            velocity = Vector3.Reflect(velocity, collisionNorm);
        }
        
        transform.position = transform.position + velocity;
        direction = velocity.normalized;
        transform.forward = direction;

        isCollision = false;
    }
    /*void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            //contact = collision.contacts[0];
            //Debug.Log("Point of contact: " + contact.normal);
            //print(contact.otherCollider.tag);
        if(contact.otherCollider.tag == "Shots")
            {
                return;
            }
        collisionNorm = contact.normal;
        }
        isCollision = true;
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.tag == "Shots")
            {
                return;
            }
            
        }
        isCollision = true;
    }*/

    void OnTriggerEnter(Collider other)
    {
        //print("enter");
        //print(other.tag);
        if(other.tag == "Shots")
        {
            return;
        }
        else if(other.tag == "Player")
        {
            caracterContorl player = other.GetComponent<caracterContorl>();
            if (player.isDashing())
            {
                return;
            }
        }
        isCollision = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.Log("Point of contact: " + hit.point);
            //Debug.Log("Normal of contact: " + hit.normal);
            collisionNorm = hit.normal;
        }
    }

}
