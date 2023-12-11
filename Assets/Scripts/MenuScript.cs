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
        PlayerPrefs.SetInt("degerim", 2);      
        SceneManager.LoadScene("tutoryýl");      
    }
    public void Serbest()
    {
        PlayerPrefs.SetInt("oyunturu", 1);
        SceneManager.LoadScene("SerbestOyun");
    }
    public void Toplama()
    {
        PlayerPrefs.SetInt("oyunturu", 2);
        SceneManager.LoadScene("SerbestOyun");
    }
    public void Cikarma()
    {
        PlayerPrefs.SetInt("oyunturu", 3);
        SceneManager.LoadScene("SerbestOyun");
    }




}