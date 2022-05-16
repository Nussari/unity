using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private int count;
    public Image[] gems;
    public Sprite gem;


    void Start()
    {
        count = 0; //resetta stig
        for (int i = 0; i < gems.Length; i++){
            if (i+1 > count){
                gems[i].enabled = false;
            }else{
                gems[i].enabled = true;
            }
        } //fel demantana
    }

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("jump", true); //geri þetta fyrir animation
        }
        if (transform.position.y <= -2){ //drep leikmann ef dettur i holu
            SceneManager.LoadScene("ded");
        }
        for (int i = 0; i < gems.Length; i++){
            if (i+1 > count){
                gems[i].enabled = false;
            }else{
                gems[i].enabled = true;
            }
        } //fer yfir demantana
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding(){
        animator.SetBool("jump", false);
    }

    void OnTriggerEnter2D(Collider2D collision){
        collision.gameObject.SetActive(false);
        if (collision.tag == "Coin"){
            count++;
        }else if (collision.tag == "Enemy"){
            count--;
            if (count < 0){
                SceneManager.LoadScene("ded");
            }
        }else if (collision.tag == "door"){
            PlayerPrefs.SetInt("score", count); //vista i playerprefs svo eg geti synt i lokaskja
            SceneManager.LoadScene("win");
        }
    }
}
