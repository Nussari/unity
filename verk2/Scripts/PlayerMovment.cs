using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 20;
    public float sideways = 20;
    public float jump = 20;
    public static int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI newPoints;
    public GameObject ded;
    public GameObject hurt;
    public Transform spawnPoint;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==1){ //checka hvort se verið að loada fyrsta leveli
            count = 0; //resetta stig
        }
        ded.SetActive(false); //fel object
        hurt.SetActive(false); //fel object
        newPoints.color = new Color32(0, 0, 0, 0); //fel object
        countText.text = "Stig: " + count.ToString(); // syni stig
    }
    void FixedUpdate()
    {
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (transform.position.y <= -1) //ef gæinn dettur af mappinu
        {
            Endurræsa();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space) && transform.position.y <= 0.5)
        {
            transform.position += transform.up *jump;
        }
        if (transform.position.y<=-1)
        {
            Endurræsa();
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "mark")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == "pikk")
        {
            collision.gameObject.SetActive(false);
            count = count + 5;
            newPoints.text = "+5"; //skrifa stigin sem leikmaður var að fa
            newPoints.color = new Color32(7, 173, 0, 255); //syni textann
            StartCoroutine(NewPoints());
            SetCountText();
        }
        if (collision.tag == "hindrun")
        {
            collision.gameObject.SetActive(false);
            count = count -3;
            newPoints.text = "-3"; //skrifa stigin sem leikmaður var að fa
            newPoints.color = new Color32(255, 21, 21, 255); //syni textann
            StartCoroutine(NewPoints());
            SetCountText();
            StartCoroutine(Hurt()); //stoppa leikmann og geri skjainn rauðann i 1sek
        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();
        PlayerPrefs.SetInt("score", count);
       
        if (count < 0)
        {
            this.enabled = false;
            ded.SetActive(true);
            StartCoroutine(Dead());
            
        }
        
    }
    IEnumerator NewPoints()
    {
        yield return new WaitForSeconds(1); //læt 1sek liða aður en eg fel textann aftur
        newPoints.color = new Color32(0, 0, 0, 0);
    }
    IEnumerator Hurt()
    {
        this.enabled = false;
        hurt.SetActive(true);
        yield return new WaitForSeconds(1);
        this.enabled = true;
        hurt.SetActive(false);
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    public void Endurræsa()
    {
        this.transform.position = spawnPoint.transform.position; //set gæann a byrjunarreit
    }

}
