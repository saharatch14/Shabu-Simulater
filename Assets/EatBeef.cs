using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBeef : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        GameManager_Shabu.instance.isDrag = false;
        GameManager_Shabu.instance.thisbeef = null;
        GameManager_Shabu.instance.Update_Score(other.gameObject.GetComponent<Meat>().realscroe);

        int test = Random.Range(0, 1);

        if (test == 0)
            AudioController.instance.PlaySFX("Chow2");
        else
            AudioController.instance.PlaySFX("Chow1");

        Destroy(other.gameObject);
    }

    /*private void OnCollisionStay(Collision other)
    {
        //GameManager_Shabu.instance.isDrag = false;
        //GameManager_Shabu.instance.thisbeef = null;
        //Destroy(other.gameObject);
        if (Input.GetMouseButtonUp(0))
        {
            GameManager_Shabu.instance.isDrag = false;
            GameManager_Shabu.instance.thisbeef = null;

            int test = Random.Range(0, 1);

            if (test == 0)
                AudioController.instance.PlaySFX("Chow2");
            else
                AudioController.instance.PlaySFX("Chow1");

            Destroy(other.gameObject);
        }
    }*/

    /*private void OnCollisionExit(Collision other)
    {
        //GameManager_Shabu.instance.isDrag = false;
        //GameManager_Shabu.instance.thisbeef = null;
        //Destroy(other.gameObject);
        if (Input.GetMouseButtonUp(0))
        {
            GameManager_Shabu.instance.isDrag = false;
            GameManager_Shabu.instance.thisbeef = null;

            int test = Random.Range(0, 1);

            if (test == 0)
                AudioController.instance.PlaySFX("Chow2");
            else
                AudioController.instance.PlaySFX("Chow1");

            Destroy(other.gameObject);
        }
    }*/


    /*private void OnTriggerStay(Collider other)
    {
        /*if(Input.GetMouseButtonUp(0))
        {
            GameManager_Shabu.instance.isDrag = false;
            GameManager_Shabu.instance.thisbeef = null;
            Destroy(other.gameObject);
        }
    }*/
}
