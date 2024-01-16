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
    public static collider col = new collider();  
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public AudioClip islemses;
    public AudioClip baslases;
    public AudioClip[] sesler;
    public AudioClip[] seslerAnaobj;

    public GameObject sestext;
    TextMeshProUGUI sestext2;
    public GameObject Puantxt;
    TextMeshProUGUI PuanTXT2;
    public GameObject IslemTXT;
    TextMeshProUGUI IslemTXT2;
    public TextMeshProUGUI puanim;
    public int puan;
    public int eski;   
    public int randomTagNumber;
    public int randomTagNumber2;
    public int toplama;
    public int cikarma;    
    public int hedef;  
    void Start()
    {
        Puantxt = GameObject.FindWithTag("puanim");
        PuanTXT2 = Puantxt.GetComponent<TextMeshProUGUI>();     
        if (PlayerPrefs.GetInt("oyunturu")>1)
        {
            
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = islemses;
            audioSource.Play();
            randomTagNumber2 = Random.Range(0, 10);
            IslemTXT = GameObject.FindGameObjectWithTag("Islemim");
            IslemTXT2 = IslemTXT.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            sestext = GameObject.FindWithTag("sestext");
            sestext2 = sestext.GetComponent<TextMeshProUGUI>();
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = baslases;
            audioSource.Play();
        }
        // Ses dosyası boş mu diye kontrol ediyor ve rastgele bir sayı oluşturarak hedefi beliryip ses dosyası çalınıyor
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say oluşturur.       
        toplama = randomTagNumber + randomTagNumber2;
        cikarma= randomTagNumber - randomTagNumber2;        
        sayiKontrol();
    }
    private void OnTriggerEnter(Collider other)
    {//Hedeflere ulaşıldığında hedefleri 3 saniye gizleyip yeni hedef oluşturuyor
       if (other.gameObject.tag == hedef.ToString())
        {
            puan += 2;
            Puantxt.GetComponent<TextMeshProUGUI>();
            PuanTXT2.text = puan.ToString();         
            sayiOlustur();
            other.gameObject.SetActive(false);  // Objeyi 3 saniyeliğine kapat                
            StartCoroutine(ActivateAfterDelay(other.gameObject, 3f));  // 3 saniye sonra objeyi geri aç
        }     
        IEnumerator ActivateAfterDelay(GameObject obj, float delay) // 3 saniye sonra objeyi geri açan işlem
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(true);
           }      
    } 
    public void sayiOlustur()
    {    
        if (PlayerPrefs.GetInt("oyunturu")==1 )
        {// oyun türü 1 e  eşitse sadece 1 rakam olacak
            eski = randomTagNumber;
            randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            sayiKontrol();
        }
        else if (PlayerPrefs.GetInt("oyunturu") == 2  )
        {// oyun türü 2 ve ya 3 ise 2 rakam  oluşturulup toplama ve ya çıkarma işlemi yapılacak
            eski = toplama;
            randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            randomTagNumber2 = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            toplama = randomTagNumber + randomTagNumber2;            
            sayiKontrol();
        }
        else if (PlayerPrefs.GetInt("oyunturu") == 3)
        {
            eski = cikarma;
            randomTagNumber = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.
            randomTagNumber2 = Random.Range(0, 10); // 0 ile 9 aras�nda rastgele bir say� olu�turur.           
            cikarma = randomTagNumber - randomTagNumber2;
            sayiKontrol();
        }
    }
    public void sayiKontrol()
    {//Oluşturulan sayı bir önceki sayı ile aynı mı diye bakıyoruz. Aynı olmasını istemiyoruz. Çünkü o hedef yok edildiği için 3 saniye boyunca gelmeyecek
    
        if (PlayerPrefs.GetInt("oyunturu") == 1  && randomTagNumber ==eski )
        {
            sayiOlustur();
        }
        else if (PlayerPrefs.GetInt("oyunturu") == 2 && toplama > 9)
        {
            sayiOlustur();
        }
        else if (PlayerPrefs.GetInt("oyunturu") == 3 && cikarma < 0  )          
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
        
        if (PlayerPrefs.GetInt("oyunturu") == 1 )
        {
            sestext2.GetComponent<TextMeshProUGUI>();
            sestext2.text=randomTagNumber.ToString();
            hedef = randomTagNumber;
            audioSource.clip = sesler[randomTagNumber];
            audioSource.Play();
        }
        // SES DOSYALARI AYARLANACAK

        else if (PlayerPrefs.GetInt("oyunturu") == 2)
        {
            hedef = toplama;
            IslemTXT.GetComponent<TextMeshProUGUI>();
            IslemTXT2.text = randomTagNumber.ToString() + " + " + randomTagNumber2.ToString();
        }
        else if (PlayerPrefs.GetInt("oyunturu") == 3 )
        {
            hedef = cikarma;
            IslemTXT.GetComponent<TextMeshProUGUI>();
            IslemTXT2.text = randomTagNumber.ToString() + " - "+randomTagNumber2.ToString();                   
        }     
    }
    public void sesiptal()
    {
            audioSource.Stop();
    }
    public string deger;
    public int ses;
    public void sesTekrar()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        deger = sestext2.text;
        ses=Convert.ToInt32(deger);
        audioSource.clip = seslerAnaobj[ses];
        audioSource.Play();


    }
} 
