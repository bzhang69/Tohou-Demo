using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{

    public DLight[] dl = new DLight[0];
    public int light_count = 0;
    public float ct = 1f;

    private float cool_time = 0f;
    private int light_n = 0;

	void Start ()
    {
        cool_time = ct;
		
	}
	
	void Update ()
    {
        cool_time -= Time.deltaTime;
        if(cool_time < 0f && light_n < 100)
        {
            for (int j = 0; j < dl.Length; j++)
            {
                Instantiate(dl[j], new Vector3(50, 10, 50), transform.rotation);
            }
            light_n += 4;
            cool_time = ct;
        }
        
    }
}
