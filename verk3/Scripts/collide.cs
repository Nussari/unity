using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class collide : MonoBehaviour
{
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource pointSound;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;
    public static int count;
    public int health = 100;
    public GameObject hurt;
    
    void Start()
    {
        count = 0; //resetta stig
        health = 100; //resetta lif
        countText.text = "Stig: " + count.ToString(); // syni stig
        healthText.text = "Lif: " + health.ToString(); // syni lif
        hurt.SetActive(false); //fel panel
    }
    void FixedUpdate()
    {
        if (transform.position.y <= 75) //checka hvort leikmaður hafi dottið af
        {
            SceneManager.LoadScene("ded");
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "water") //drep leikmann ef dettur i vatn
        {
            SceneManager.LoadScene("ded");
        } else if (collision.tag == "pikk" || collision.tag == "supapikk")
        {
            pickup(collision);
            
        } else if (collision.tag == "goon")
        {
            collision.gameObject.SetActive(false);
            health = health - 10;
            healthText.text = "Lif: " + health.ToString();
            hurtSound.Play(); //spila hljoð þegar leikmaður meiðir sig
            if (health <= 0)
            {
                SceneManager.LoadScene("ded");
            }
            StartCoroutine(Hurt());
        } else if (collision.tag == "medkit" && health < 100) //tek ekki medkit ef leikmaður þarf það ekki
        {
            collision.gameObject.SetActive(false);
            health = health + 10;
            healthText.text = "Lif: " + health.ToString();
            StartCoroutine(HealthPickup());
        }
    }
    IEnumerator Hurt() //geri skja og texta rauðann
    {
        hurt.SetActive(true);
        healthText.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(1);
        healthText.color = new Color32(255, 255, 255, 255);
        hurt.SetActive(false);
    }
    IEnumerator PickupColor() //geri texta grænan
    {
        countText.color = new Color32(19, 255, 0, 255);
        yield return new WaitForSeconds(1);
        countText.color = new Color32(255, 255, 255, 255);
    }
    IEnumerator HealthPickup() //geri texta grænan
    {
        healthText.color = new Color32(19, 255, 0, 255);
        yield return new WaitForSeconds(1);
        healthText.color = new Color32(255, 255, 255, 255);
    }
    void pickup(Collider obj)
    {
        obj.gameObject.SetActive(false);
        pointSound.Play();
        if (obj.tag == "pikk")
        {
            count++;
        } else //gef 3 stig ef það er græn coin
        {
            count = count + 3;
        }
        countText.text = "Stig: " + count.ToString();
        if (count >= 20) //leikmaður vinnur ef hann fær 20 stig
        {
            SceneManager.LoadScene("win");
        }
        StartCoroutine(PickupColor());
    }
}
