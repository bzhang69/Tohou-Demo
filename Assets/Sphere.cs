using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 velocity = new Vector3 (0f,0f,0f);
    public float speed = 1f;
    private Vector3 direction = new Vector3(0f, 0f, 1f);
    private Vector3 collisionNorm = new Vector3(0f, 0f, 0f);
    private bool isCollision;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 tmpPosition = transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //speed += 0.01f;
        if (isCollision)
        {
            velocity = Vector3.Reflect(velocity, collisionNorm);
            //velocity = direction * speed;
            isCollision = false;
        }
        else
        {
            //transform.position = transform.position + movement / 2;
            //transform.position = transform.position + new Vector3(0, 0, 0.1f);
            //direction = direction + new Vector3(0, 0, 0.1f) / 4;
            //velocity = direction * speed;
        }
        //velocity = direction * speed;
        velocity = velocity + new Vector3(0, 0, 0.1f);
        transform.position = transform.position + velocity;
        //print(velocity);
    }

    /*void OnCollisionEnter(Collision collision)
    {
        isCollision = true;
        //foreach (ContactPoint contact in collision.contacts)
        //{     
        ContactPoint contact = collision.contacts[0];
            Debug.Log("Point of contact: " + contact.normal);
            collisionNorm = contact.normal;
            Debug.Log(velocity);
        //}
    }

    void OnCollisionStay(Collision collision)
    {
        isCollision = true;
    }*/

    void OnTriggerEnter(Collider other)
    {
        //print("enter");
        isCollision = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log("Point of contact: " + hit.point);
            Debug.Log("Normal of contact: " + hit.normal);
            collisionNorm = hit.normal;
        }
    }

}
