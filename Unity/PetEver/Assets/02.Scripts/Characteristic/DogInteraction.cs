using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteraction : MonoBehaviour
{
    public GameObject DogCamera;
    public Animator dogAnimator;
    public GameObject touchtracking;
    private float time_start;
    private float reset_flag;


    // Start is called before the first frame update
    void Start()
    {
        DogCamera = GameObject.Find("CharacterCamera");
        dogAnimator = GameObject.FindGameObjectWithTag("OwnerDog").GetComponent<Animator>();
        touchtracking = GameObject.Find("spine.033");
        reset_flag = 0;

    }

    // Update is called once per frame
    // https://ssscool.tistory.com/336
    void Update()
    {   

        if (Input.touchCount > 0)
        {
            // 싱글 터치.
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos;
            Ray ray;
            RaycastHit hit;
            Vector3 touchPosToVector3;

 
            switch (touch.phase)
            {
                case TouchPhase.Began: // when touch starts


                    touchPosToVector3 = new Vector3(touch.position.x,touch.position.y, 0);
                    //touchPos = DogCamera.GetComponent<Camera>().ScreenToWorldPoint(touchPosToVector3);
                    ray = DogCamera.GetComponent<Camera>().ScreenPointToRay(touchPosToVector3); 
                    if (Physics.Raycast(ray,out hit))
                    {
                        //Debug.Log(hit.collider.gameObject.name); 
                        if(hit.collider.gameObject.name == "footTouch_R")
                        {
                            dogAnimator.SetTrigger("feetup_L");
                        }
                        else if(hit.collider.gameObject.name == "footTouch_L")
                        {
                            dogAnimator.SetTrigger("feetup_R");
                        }
                    }
                    else
                    {                        

                    }
 
                    break;
                case TouchPhase.Moved:
                    if (reset_flag == 0)
                    {
                        time_start = Time.time;
                    }
                    reset_flag = 1;
                    touchPosToVector3 = new Vector3(touch.position.x,touch.position.y, 0);
                    ray = DogCamera.GetComponent<Camera>().ScreenPointToRay(touchPosToVector3); 
                    if (Physics.Raycast(ray,out hit))
                    {
                        if((hit.collider.gameObject.name == "headTouch") && (Time.time-time_start) > 1.0f)
                        {
                            dogAnimator.SetTrigger("heading");
                        }
                    }
                    break;
 
                case TouchPhase.Stationary:
                    // 터치 고정 시.
                    break;
 
                case TouchPhase.Ended:
                    reset_flag = 0;
                    break;
 
                case TouchPhase.Canceled:
                    // 터치 취소 시. ( 시스템에 의해서 터치가 취소된 경우 (ex: 전화가 왔을 경우 등) )
                    break;
            }
        }
    }
}
