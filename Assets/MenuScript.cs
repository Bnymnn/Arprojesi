using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    
    
    public void Secim()
    { 
        SceneManager.LoadScene("Secim");       
    }
    public void Egitm()
    {
        SceneManager.LoadScene("Egitm");      
    }
    public void Serbest()
    {
        PlayerPrefs.SetInt("oyunTur", 1);
        SceneManager.LoadScene("SerbestOyun");
    }
    public void Toplama()
    {
        PlayerPrefs.SetFloat("oyunTur", 2);
        SceneManager.LoadScene("SerbestOyun");
    }
    public void Cikarma()
    {
        PlayerPrefs.SetInt("oyunTur", 3);
        SceneManager.LoadScene("SerbestOyun");
    }




}