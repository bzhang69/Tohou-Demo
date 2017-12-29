using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawn : MonoBehaviour {

    public GameObject[] shot = new GameObject[0];
    public float fireRate = 1.0f;
    private float nextFire = 0f;
    private GameObject shotsClone;
    private GameObject[] shotsArray;
    private int shotsCount = 0;
    public float shootingRotation = 10;
    public Transform ParentBoss;
    public int maxShots = 300;
    private bool killing = false;

    private void Start()
    {
        shotsArray = new GameObject[maxShots];
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > nextFire)
        {
            //rb.angularVelocity = (new Vector3(0, Random.Range(-1.5f, 1.5f), 0));
            
            nextFire = Time.time + fireRate;
            transform.RotateAround(ParentBoss.position, Vector3.up, shootingRotation* Mathf.Sin(Time.time));
            Shooting();
            //transform.Rotate(0, Random.Range(-30,30), 0);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            DestroyCloneShots();
        }
    }

    void Shooting()
    {

        shotsClone = Instantiate(shot[0], transform.position, transform.rotation) as GameObject;
        Destroy(shotsClone, 9);
        shotsArray[shotsCount] = shotsClone;
        shotsCount++;
        //print(shotsCount);

        if (shotsCount==maxShots-1)
        {
            /*print("distroy");
            //DestroyCloneShots();
            killing = true;*/
            shotsCount = 0;
        }
        /*if (killing)
        {
            DestroyLastShot();
        }*/
    }

    void DestroyCloneShots()
    {
        for (int i = 0; i < shotsCount; i++)
        {
            Destroy(shotsArray[i], 0);
        }
    }

    void DestroyLastShot()
    {
        if (shotsCount == 0)
        {
            Destroy(shotsArray[maxShots - 1], 0);
        }
        else
        {
            Destroy(shotsArray[shotsCount - 1], 0);
        }

    }
}
