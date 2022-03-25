using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    public void Byrja()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void Endir()
    {
        Application.Quit();
    }
    
}
