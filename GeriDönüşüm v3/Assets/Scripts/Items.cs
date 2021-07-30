using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Transform tr;
    Rigidbody rb;

    Vector3 ScreenPoint;
    Vector3 offset;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log("deneme");
    }

    private void OnMouseDown()
    {
        if (Mat.mat.isFinish == false)
        {
            tr.localScale = tr.localScale * GameManager.instance.size;
            rb.useGravity = false;
            ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));
        }
    }
    private void OnMouseDrag()
    {
        if (Mat.mat.isFinish == false)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;


            rb.position = cursorPosition;
            rb.MovePosition(new Vector3(rb.position.x, 5.5f, rb.position.z));
        }

    }
    private void OnMouseUp()
    {
        if (Mat.mat.isFinish == false)
        {
            tr.localScale = tr.localScale / GameManager.instance.size;
            rb.useGravity = true;
        }
    }
}