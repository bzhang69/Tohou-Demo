using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLight : MonoBehaviour
{

    public float velocity = 0;
    public float direction = 0;

    private Vector3 v = new Vector3(0, 0, 0);

	void Start ()
    {
        Light l = gameObject.AddComponent<Light>();
        l.type = LightType.Point;
        l.range = 20;
        l.shadows = LightShadows.Hard;

        v.x = velocity * Mathf.Sin(direction / 180 * Mathf.PI);
        v.z = velocity * Mathf.Cos(direction / 180 * Mathf.PI);
    }

	void Update ()
    {
        transform.position += v * Time.deltaTime;
	}
}
