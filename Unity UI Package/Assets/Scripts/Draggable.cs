using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private int id;

    Vector3 offset;
    float mouseZPos;

    // Start is called before the first frame update
    void Start()
    {
        DragDropEvents.instance.onDrop += OnDropped;
        DragDropEvents.instance.onDrag += OnDrag;
        DragDropEvents.instance.onMouseDown += OnMouseClick;
        id = gameObject.GetInstanceID();
    }

    void OnDropped(int id)
    {
        if (id == this.id)
        {
            //need to give users a choice of what happens here
        }
    }

    void OnDrag(int id)
    {
        if(id == this.id)
        {
            //users choice
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    void OnMouseClick(int id)
    {
        if(id == this.id)
        {
            //set up variables for drag
            mouseZPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            offset = gameObject.transform.position - GetMouseWorldPos();
        }
    }

    private void OnMouseEnter()
    {
        //DragDropEvents.instance.OnDrop(id);
    }

    private void OnMouseDown()
    {
        DragDropEvents.instance.OnMouseDown(id);
    }

    private void OnMouseDrag()
    {
        DragDropEvents.instance.OnDrag(id);
    }
    private void OnDestroy()
    {
        DragDropEvents.instance.onDrop -= OnDropped;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mouseZPos;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
