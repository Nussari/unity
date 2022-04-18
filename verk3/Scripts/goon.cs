using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goon : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 5f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("dood").transform; //finn leikmanninn
    }

    void Update()
    {
        Vector3 stefna = player.position - transform.position;
        stefna.Normalize();
        movement = stefna;
    }
    private void FixedUpdate()
    {
        Hreyfing(movement);
    }
    void Hreyfing(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * hradi * Time.deltaTime));
    }
}
