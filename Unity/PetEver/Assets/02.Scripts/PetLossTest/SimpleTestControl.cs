using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTestControl : MonoBehaviour
{
    CanvasGroup testCanvas;
    CanvasGroup testGuide;
    CanvasGroup chatNnoti;

    void Start()
    {
        testCanvas = GameObject.Find("PetLossTestPannel").GetComponent<CanvasGroup>();
        testGuide = GameObject.Find("PetLossTestGuide").GetComponent<CanvasGroup>();
        chatNnoti = GameObject.Find("ChatAndNoti").GetComponent<CanvasGroup>();
    }

    IEnumerator OneSecDelay()
    {
        yield return new WaitForSeconds(3.0f);
    }

    void showTestGuide(bool showing)
    {
        if (showing == true) {
            testGuide.alpha = 1;
        } else {
            testGuide.alpha = 0;
        }
        testGuide.interactable = showing;
        testGuide.blocksRaycasts = showing;
    }

    

    public void OnExitClicked()
    {
        // Debug.Log(SimpleTest.totalScore);
        
        // Initialize the totalScore
        SimpleTest.totalScore = SimpleTest.DEFAULT_TOTALSCORE;
        GameObject previousCanvas = GameObject.FindGameObjectWithTag("SimpleTest");
        Destroy(previousCanvas);
        HealingGuide.OnSimpleTestExitClicked();
        
        StartCoroutine(OneSecDelay());
        showTestGuide(true);
        StartCoroutine(OneSecDelay());
        showTestGuide(false);

        showPetLossTest();
    }

    // private void startPetlossTest()
    // {
    //     // StartPoint = GameObject.Find("TestPosition").transform.position;
    //     // collision.transform.position = StartPoint;

    //     showPetLossTest();
    // }

    private void showPetLossTest()
    {
        testCanvas.alpha = 1;
        testCanvas.interactable = true;
        testCanvas.blocksRaycasts = true;

        chatNnoti.alpha = 0;
        chatNnoti.interactable = false;
        chatNnoti.blocksRaycasts = false;
    }

    private void hidePetLossTest()
    {
        testCanvas.alpha = 0;
        testCanvas.interactable = false;
        testCanvas.blocksRaycasts = false;

        chatNnoti.alpha = 1;
        chatNnoti.interactable = true;
        chatNnoti.blocksRaycasts = true;
    }

    private void hideGuide() {
        GameObject.Find("PetLossTestGuide").SetActive(false);
    }
}
