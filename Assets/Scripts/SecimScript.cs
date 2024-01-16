using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecimScript : MonoBehaviour
{
    
    public void sifir()
    {
        
        PlayerPrefs.SetInt("degerim", 0);
        SceneManager.LoadScene("Menu");


    }
    public void bir()
    {
        PlayerPrefs.SetInt("degerim", 1);
        SceneManager.LoadScene("Menu");
    }
    public void iki()
    {
        PlayerPrefs.SetInt("degerim", 2);
        SceneManager.LoadScene("Menu");

    }
    public void uc()
    {
        
        PlayerPrefs.SetInt("degerim", 3);
        SceneManager.LoadScene("Menu");

    }
    public void udortc()
    {

        PlayerPrefs.SetInt("degerim", 4);
        SceneManager.LoadScene("Menu");

    }
    public void geri()
    {
        SceneManager.LoadScene("Menu");

    }
}
