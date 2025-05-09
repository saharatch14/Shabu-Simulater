using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGrab : MonoBehaviour
{
    private bool isDrag = false;
    public LayerMask layersToHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        /*if (Input.GetMouseButtonDown(0))
        {             
            hit.collider.gameObject.transform.position = crosshair.GetPoint(1.0f);
            hit.collider.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }*/
        if(Input.GetMouseButtonDown(0))
        {
            Ray crosshair;
            RaycastHit hit;
            crosshair = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(crosshair, out hit, 50,layersToHit))
            {
                hit.collider.gameObject.transform.position = crosshair.GetPoint(1.0f);
                hit.collider.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                isDrag = true;
            }
        }
        if (isDrag)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10));
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }
    }
}
