using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] private float basescroe;
    [SerializeField] private float baseTimerReady = 30;
    [SerializeField] private float currentTimer = 0;

    public float scroe = 0;
    public int realscroe = 0;

    // Update is called once per frame
    private void Start()
    {
        scroe = basescroe;
    }
    void Update()
    {
        if (currentTimer >= baseTimerReady)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetComponent<Outline>().Setup(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("hotwater") && GameManager_Shabu.instance.GetCurrentTimer() > 0 && GameManager_Shabu.instance.isDrag == false)
        {
            //Debug.Log("collisiion");
            currentTimer += Time.deltaTime;
            if(currentTimer >= baseTimerReady)
            {
                //scroe -= Time.deltaTime;
                scroe -= Time.deltaTime;
                realscroe = (int)scroe;
            }
        }
        if (other.gameObject.CompareTag("None") && GameManager_Shabu.instance.isDrag == false)
        {
            Destroy(other.gameObject);
        }
    }
    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("hotwater"))
        {
            Debug.Log("collisiion");
            currentTimer += Time.deltaTime;
        }
    }*/
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hotwater"))
        {
            Debug.Log("collisiion");
            currentTimer += Time.deltaTime;
        }
    }*/
}
