using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("lvl1"); //loada fyrsta level
    }
    public void tutorial()
    {
        SceneManager.LoadScene("tutorial"); //loada leiðbeiningum
    }
    public void stop()
    {
        Application.Quit(); //slekk á leik
    }
    public void back()
    {
        SceneManager.LoadScene("start"); //fer á byrjunarskjá
    }
    
}