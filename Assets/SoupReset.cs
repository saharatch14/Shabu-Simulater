using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupReset : MonoBehaviour
{
    public GameObject ForAnimetion;
    public void Start()
    {
        Animator animation = ForAnimetion.GetComponent<Animator>();
    }

    public void OnMouseOver()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            //ForAnimetion.SetActive(true);
            StartCoroutine(RunAnimetion());
            //ForAnimetion.SetActive(false);
        }
    }

    IEnumerator RunAnimetion()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        ForAnimetion.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        GameManager_Shabu.instance.Update_SoapRefill();
        yield return new WaitForSeconds(5);
        ForAnimetion.SetActive(false);
        GameManager_Shabu.instance.ResetTimer();
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    // Update is called once per frame
    public void OnMouseExit()
    {
        Debug.Log("Exit");
    }
}
