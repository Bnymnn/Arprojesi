using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{// deðiþkenler ve diziler vs.
    public GameObject kutu;
    public GameObject buton;
    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;
    MenuScript menusc = new MenuScript();
    [SerializeField] private Vector3 prefaboffset;
    [SerializeField] private GameObject[] dragonPrefab;


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
    }
}
