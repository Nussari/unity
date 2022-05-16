using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float throwSpeed = 100f;

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {     
            Instantiate(bullet, firePoint.position, firePoint.rotation); //spawna hnif
        }
    }
}
