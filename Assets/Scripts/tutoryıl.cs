using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class tutoryıl : MonoBehaviour
{
    public GameObject Puantxt_egtm;
    TextMeshProUGUI PuanTXT2_egtm;
    public AudioClip[] sesler;
    public GameObject siyahPanelim;
    public GameObject sonPanel;
    public Image imagem;
    public AudioSource tutoryilsesim;
    public AudioSource b;
    public AudioSource audioSource;  
    public int puan;  
    public int i =0;
 
    void Start()
    {// anlatım sesi çalacak ve hedef dizideki ilk eleman olacak
        
        Puantxt_egtm = GameObject.FindWithTag("puanim");
        sonPanel = GetComponent<GameObject>();
        PuanTXT2_egtm = Puantxt_egtm.GetComponent<TextMeshProUGUI>();    
        tutoryilsesim.Play();     
    }
  

    private void OnTriggerEnter(Collider other)
    {//Hedeflere ulaşıldığında hedefleri  kapatıyor
        
        if (other.gameObject.tag == i.ToString())
        {   
            puan += 2;
            Puantxt_egtm.GetComponent<TextMeshProUGUI>();
            PuanTXT2_egtm.text = puan.ToString();           
            Destroy(GameObject.FindWithTag(i.ToString()));
            i++;
            audioSource = gameObject.AddComponent<AudioSource>();          
            audioSource.clip = sesler[i];
            audioSource.Play();                       
        }
       
    }  
    public void baslaButonu() 
    { 
        siyahPanelim.SetActive(false);
        tutoryilsesim.Stop();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = sesler[i];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = sesler[i];
        audioSource.Play();

        }        
    }
    public void sesTekrar()
    {audioSource.Stop();
        string deger = PuanTXT2_egtm.text;
        int ses = Convert.ToInt32(deger)/2;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sesler[ses];
        audioSource.Play();
    }
}
