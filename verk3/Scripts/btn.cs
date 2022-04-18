using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class btn : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; //næ i musina
    }
    public void start()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void stop()
    {
        Application.Quit();
    }
    public void back()
    {
        SceneManager.LoadScene("start");
    }
    
}
