using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    public float xMax, xMin, zMax, zMin;
    private Collider cld;

	// Use this for initialization
	void Start () {
        cld = GetComponent<Collider>();
        xMax = transform.position.x + cld.bounds.size.x / 2;
        xMin = transform.position.x - cld.bounds.size.x / 2;
        zMax = transform.position.z + cld.bounds.size.z / 2;
        zMin = transform.position.z - cld.bounds.size.z / 2;

    }

    /*public Quaternion GetBounds ()
    {
        return new Quaternion(xMax, xMin, zMax, zMin);
    }*/
}
