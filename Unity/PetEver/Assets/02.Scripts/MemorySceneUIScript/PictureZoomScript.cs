using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureZoomScript : MonoBehaviour
{
    private Material refFrame;


    // Start is called before the first frame update
    void Start()
    {
        
        refFrame = GameObject.Find("Frame1").GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject);
    }


}
