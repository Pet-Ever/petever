using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogEscort : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; 
    public static bool welcomeEscort;
    public static bool waitOwner;
    private Vector3[] escortPoint; 
    private GameObject owner, emotionBubble, questionMark;
    private float dis_Owner2Dog; // distance between owner and dog
    private float dis_Owner2Point; // distance between owner and point
    private float dis_Dog2Point; // distance between dog and point
    private int escortPointNum;
    private LineRenderer lineRenderer;
   
    void Awake()
    {
        welcomeEscort = false;
        waitOwner = false;
        dis_Owner2Point = 10f;
        escortPointNum = 0;


        escortPoint = new Vector3[2]; 
        escortPoint[0] = GameObject.Find("checkPoint1").GetComponent<Transform>().position;
        escortPoint[1] = GameObject.Find("checkPoint2").GetComponent<Transform>().position;
       // escortPoint[2] = GameObject.Find("checkPoint3").GetComponent<Transform>().position;
        //owner = GameObject.FindGameObjectWithTag("Owner");


    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        owner = GameObject.FindGameObjectWithTag("Owner");
        emotionBubble = GameObject.Find("emotionBubble");
        questionMark = GameObject.Find("questionMark");

        // when dog starts to escort, make line it's path
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.5f;
        lineRenderer.material.color = Color.blue;
        lineRenderer.enabled = false;

        
        StartCoroutine(DogEscorting());

    }

    // Update is called once per frame
    void Update()
    {

        dis_Owner2Dog = Vector3.Distance(owner.transform.position, gameObject.transform.position);
        dis_Owner2Point = Vector3.Distance(owner.transform.position, escortPoint[escortPointNum]);
        dis_Dog2Point = Vector3.Distance(gameObject.transform.position, escortPoint[escortPointNum]);



    }


    IEnumerator DogEscorting()
    {

       // escortPoint.Length    
        emotionBubble.SetActive(false);
        questionMark.SetActive(false);


        while(true)
        {
            if (welcomeEscort)
            {
                lineRenderer.enabled = true;    
                navMeshAgent.SetDestination(escortPoint[escortPointNum]);
                lineRenderer.SetPosition(0,gameObject.transform.position);

                if (dis_Owner2Dog > 12f)
                {
                    waitOwner = true;
                    navMeshAgent.isStopped = true;
                    navMeshAgent.velocity = Vector3.zero;

                    emotionBubble.SetActive(true);
                    questionMark.SetActive(true);

                    LookOwner();
                    //gameObject.transform.LookAt(owner.transform);
                }

                else
                {
                    waitOwner = false;
                    //navMeshAgent.SetDestination(escortPoint[escortPointNum]);

                    emotionBubble.SetActive(false);
                    questionMark.SetActive(false);

                    navMeshAgent.isStopped = false;   
                }


                if (dis_Owner2Point < 4f)
                {
                    if (escortPointNum < (escortPoint.Length-1))
                    {
                        escortPointNum++; 
                    }

                    else
                    {
                        welcomeEscort = false;
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);

            drawPath();
        }


    }

    void LookOwner()
    {
        if (owner != null)
        {
            Vector3 dir = (owner.transform.position-gameObject.transform.position);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(dir),Time.deltaTime*50f);
        }
    }


    void drawPath()
    {
        int length = navMeshAgent.path.corners.Length;
        lineRenderer.positionCount = length;

        for (int i = 1; i < length; i++)
            lineRenderer.SetPosition(i, navMeshAgent.path.corners[i]);
    }
}
