using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    Quaternion SpwanRot;

    private void Start()
    {
        SpwanRot = transform.rotation;
    }
    // Start is called before the first frame update
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        //transform.rotation = SpwanRot;
    }

    private void OnMouseDrag()
    {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Position.y = 1.5f;

        transform.position = Position;
        //transform.rotation = SpwanRot;
    }
}
