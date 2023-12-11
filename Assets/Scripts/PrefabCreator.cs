using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{// deðiþkenler ve diziler vs.
    public GameObject kutu;
    public GameObject buton;
    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;
    
    [SerializeField] private Vector3 prefaboffset;
    [SerializeField] private GameObject[] dragonPrefab;

    public GameObject islem;
    public GameObject[] kupler;
    public GameObject dragonegg;
    public GameObject yumurtaliklar;
    public GameObject helipad;




    private void OnEnable()
    {//þu an boþ
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnimageChanged;
    }
    private void OnimageChanged(ARTrackedImagesChangedEventArgs obj)
    {
     
    }
    public void butonBasma()
    {//x 14 y 1,57 z 0,48  bu kordinatlarda seçili olan karakteri canlandýrma
     
      Vector3 dogmaPozisyonu = new Vector3(15f, 1.57f, 0.50f); // X=0, Y=0, Z=0 gibi bir pozisyon belirleyebilirsiniz
      Quaternion dogmaRotasyonu = Quaternion.identity; // Rotasyon olmadan baþlatmak için
      dragon = Instantiate(dragonPrefab[PlayerPrefs.GetInt("degerim")], dogmaPozisyonu, dogmaRotasyonu);    
      buton.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("oyunturu") > 1)
        {
            islem.SetActive(true);
        }

        if (PlayerPrefs.GetInt("degerim") == 0) 
        {
            
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(dragonegg, kupler[i].transform.position, kupler[i].transform.rotation);

                }
            
        }
        else if (PlayerPrefs.GetInt("degerim") == 1)
        {

            for (int i = 0; i < 10; i++)
            {
                Instantiate(yumurtaliklar, kupler[i].transform.position, kupler[i].transform.rotation);

            }

        }
        else if (PlayerPrefs.GetInt("degerim") == 2 || PlayerPrefs.GetInt("degerim")==3)
        {

            for (int i = 0; i < kupler.Length; i++)
            {
                Instantiate(helipad, kupler[i].transform.position, kupler[i].transform.rotation);

            }

        }

    }
    public void cikis()
    {
        SceneManager.LoadScene("Menu");
    }
}
