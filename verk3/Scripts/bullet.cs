using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody rb;
    public GameObject medkit;
    void Start()
    {
        rb.velocity = transform.forward * speed;
        //countText = GameObject.Find("lives").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag=="goon")
        {
            Destroy(collision.gameObject);//eyðir kassanum           
            Medkit(); //spawna medkit þegar ovinur er drepinn
        }
       
    }
    void Medkit()
    {
        Instantiate(medkit, transform.position, new Quaternion(0, 0 , 0, 1));
    }
}
