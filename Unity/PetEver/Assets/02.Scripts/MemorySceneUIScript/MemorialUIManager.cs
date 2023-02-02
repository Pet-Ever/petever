using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //namespace for using UI system
//using UnityEngine.Events; //namespace for using Event system API
using UnityEngine.EventSystems;


public class MemorialUIManager : MonoBehaviour
{ 
    public GameObject NewpageUI;
    private Vector3 createPoint;

    public Button LoadNewButton;
    public Button ImageBtn, TextBtn, StickerBtn;

    // public UnityAction action;

    void Awake()
    {
        createPoint = GameObject.Find("MemorialSceneCanvas").GetComponent<RectTransform>().anchoredPosition;
      //  NewpageUI = GameObject.Find("NewpageUI");
    }

// Start is called before the first frame update
    void Start()
    {
        // ImageBtn is not operate here. refer to the "UploadPicture" Script
        TextBtn.onClick.AddListener(delegate { GetText(); });
        StickerBtn.onClick.AddListener(delegate { GetSticker(); });
        LoadNewButton.onClick.AddListener(delegate { LoadNewpage(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetText()
    {

    }

    public void GetSticker()
    {

    }

    public void LoadNewpage()
    {
        Debug.Log("click");
        Instantiate(NewpageUI, createPoint, Quaternion.identity, GameObject.Find("MemorialSceneCanvas").GetComponent<RectTransform>());



    }
}