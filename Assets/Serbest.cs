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

public class Serbest : MonoBehaviour
{
    //Degiskenler, Diziler Ve Objeler
    public int puan;
    public TextMeshProUGUI puanim;
    public GameObject gectinPanel;
    public GameObject Puantxt;
    TextMeshProUGUI PuanTXT2;
    public GameObject IslemTXT;
    TextMeshProUGUI IslemTXT2;
    public int eski;
    public AudioClip[] sesler;
    public static collider col = new collider();
    public int[] dizi = new int[0];
    public int randomTagNumber;
    public int randomTagNumber2;
    public int toplama;
    public int cikarma;

    public int randomUret; 
    public AudioSource audioSource;
    
  
    void Start()
    {
        Puantxt = GameObject.FindWithTag("puanim");
        PuanTXT2 = Puantxt.GetComponent<TextMeshProUGUI>();
        IslemTXT = GameObject.FindWithTag("Islemim");
        IslemTXT2 = IslemTXT.GetComponent<TextMeshProUGUI>();
        
       
        if (PlayerPrefs.GetInt("oyunTur") == 2 || PlayerPrefs.GetInt("oyunTur") == 3)
        {
            IslemTXT.SetActive(true);
        }
        // Ses dosyası boş mu diye kontrol ediyor ve rastgele bir sayı oluşturarak hedefi beliryip ses dosyası çalınıyor
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }     
       
        randomUret = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
        Array.Resize(ref dizi, dizi.Length + 1);
        dizi[0] = randomUret;
        randomTagNumber = randomUret;
        sayiKontrol();    

    }

    private void OnTriggerEnter(Collider other)
    {//Hedeflere ulaşıldığında hedefleri 3 saniye gizleyip yeni hedef oluşturuyor
       if (other.gameObject.tag == randomTagNumber.ToString())
        {
            puan += 2;
            Puantxt.GetComponent<TextMeshProUGUI>();
            PuanTXT2.text = puan.ToString();
           // lvlAtla();
           
            other.gameObject.SetActive(false);  // Objeyi 3 saniyeliğine kapat        
            sayiOlustur();
          
            StartCoroutine(ActivateAfterDelay(other.gameObject, 3f));  // 3 saniye sonra objeyi geri aç
        }
       
        IEnumerator ActivateAfterDelay(GameObject obj, float delay) // 3 saniye sonra objeyi geri açan işlem
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
        if (PlayerPrefs.GetInt("oyunTur")==1)
        {// oyun türü 1 e  eşitse sadece 1 rakam olacak
            eski = randomTagNumber;
            randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            sayiKontrol();

        }
        else if (PlayerPrefs.GetInt("oyunTur") == 2 || PlayerPrefs.GetInt("oyunTur") == 3)
        {// oyun türü 2 ve ya 3 ise 2 rakam  oluşturulup toplama ve ya çıkarma işlemi yapılacak
            eski = randomTagNumber;
            randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            randomTagNumber2 = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            toplama = randomTagNumber + randomTagNumber2;
            cikarma=randomTagNumber-randomTagNumber2;
            sayiKontrol();
        }
        

        
    }
    public void sayiKontrol()
    {//Oluşturulan sayı bir önceki sayı ile aynı mı diye bakıyoruz. Aynı olmasını istemiyoruz. Çünkü o hedef yok edildiği için 3 saniye boyunca gelmeyecek
    
        if (PlayerPrefs.GetInt("oyunTur") == 1 && randomTagNumber ==eski )
        {
            sayiOlustur();
        }
  
        else if (PlayerPrefs.GetInt("oyunTur") == 2 && cikarma < 0  )          
        {
             sayiOlustur();
        }          
        else if (PlayerPrefs.GetInt("oyunTur") == 3 && toplama > 9)            
        {
            sayiOlustur();
        }  
        else
            sescal();

        

    }
   
    public void sescal()
        {//ses dosyasını çalıyoruz
        
        if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        if (PlayerPrefs.GetInt("oyunTur") == 1)
        {
            audioSource.clip = sesler[randomTagNumber];
            audioSource.Play();
        }
        // SES DOSYALARI AYARLANACAK

        else if (PlayerPrefs.GetInt("oyunTur") == 2 )
        {
            IslemTXT.GetComponent<TextMeshProUGUI>();
            IslemTXT2.text = randomTagNumber.ToString() + " + " + randomTagNumber2.ToString();
            audioSource.clip = sesler[toplama];
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("oyunTur") == 3 )
        {
            IslemTXT.GetComponent<TextMeshProUGUI>();
            IslemTXT2.text = randomTagNumber.ToString() + " - "+randomTagNumber2.ToString();
            audioSource.clip = sesler[cikarma];
            audioSource.Play();
        }
        
    }
    } 
