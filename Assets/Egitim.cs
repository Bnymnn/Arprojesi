using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using TMPro;

public class Red : MonoBehaviour
{
    //Degiskenler, Diziler Ve Objeler
    public int puan;
    public TextMeshProUGUI puanim;
    public GameObject gectinPanel;
    public GameObject text;
    TextMeshProUGUI textim;
    public int eski;
    public AudioClip[] sesler;
    public static collider col = new collider();
    public int[] dizi = new int[0];
    public int randomTagNumber;
    public int randoma; 
    public AudioSource audioSource;
    
  
    void Start()
    {// Ses dosyası boş mu diye kontrol ediyor ve rastgele bir sayı oluşturarak hedefi beliryip ses dosyası çalınıyor
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
       
        text = GameObject.FindWithTag("puanim");
        textim = text.GetComponent<TextMeshProUGUI>();
        randoma = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
        Array.Resize(ref dizi, dizi.Length + 1);
        dizi[0] = randoma;
        randomTagNumber = randoma;
        sayiKontrol();

        

        

    }

    private void OnTriggerEnter(Collider other)
    {//Hedeflere ulaşıldığında hedefleri 3 saniye gizleyip yeni hedef oluşturuyor
       if (other.gameObject.tag == randomTagNumber.ToString())
        {
            puan += 2;
            text.GetComponent<TextMeshProUGUI>();
            textim.text = puan.ToString();
           // lvlAtla();
            // Objeyi 3 saniyeliğine kapat
            other.gameObject.SetActive(false);         
            sayiOlustur();
            // 3 saniye sonra objeyi geri aç
            StartCoroutine(ActivateAfterDelay(other.gameObject, 3f));
        }
        // 3 saniye sonra objeyi geri açan işlem
        IEnumerator ActivateAfterDelay(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(true);

           }
    } 
   
    public void lvlAtla()
    {
        if (puan > 10) 
        {
            gectinPanel.SetActive(true);  
        }
    }
    

    public void sayiOlustur()
    {
        eski = randomTagNumber;
        randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.

        sayiKontrol();
    }
    public void sayiKontrol()
    {//Oluşturulan sayı bir önceki sayı ile aynı mı diye bakıyoruz. Aynı olmasını istemiyoruz. Çünkü o hedef yok edildiği için 3 saniye boyunca gelmeyecek
        
        
        if (randomTagNumber==eski)
        {
            sayiOlustur();
        }
        else
        {
            sescal();

        }

    }
   
    public void sescal()
        {//ses dosyasını çalıyoruz
        
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        audioSource.clip = sesler[randomTagNumber];
        audioSource.Play();
       
    }
    } 
