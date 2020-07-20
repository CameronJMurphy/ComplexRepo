using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent OnDrag;
    public UnityEvent OnDrop;
    public UnityEvent OnDragStart;

    private bool dragging;

    // Start is called before the first frame update
    void Start()
    {
        OnDrag.AddListener(Drag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Drag()
    {
        gameObject.transform.position = Input.mousePosition;
        dragging = true;
        DragDropManager.instance.BeingDragged(gameObject.GetComponent<Draggable>());
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OnDrag.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnDragStart.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDrop.Invoke();
        dragging = false;
    }
}
