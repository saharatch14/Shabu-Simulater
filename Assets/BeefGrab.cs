using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefGrab : MonoBehaviour
{
    /*Vector3 mousePosition;
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Position.y = 1.8f;

        mousePosition = Position;
    }

    // Start is called before the first frame update
    public void OnMouseOver()
    {
        //Debug.Log("try to grab");
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Held");
            GameManager_Shabu.instance.SpwaneBeef(mousePosition);
        }
    }*/

    // Update is called once per frame
    public void OnMouseExit()
    {
        Debug.Log("Exit");
    }
}
