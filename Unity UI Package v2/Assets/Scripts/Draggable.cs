using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent OnDrag;
    public UnityEvent OnDrop;
    public UnityEvent OnDragStart;

    // Start is called before the first frame update
    void Start()
    {
        OnDrag.AddListener(Drag);
    }
    
    public void Drag()
    {
        gameObject.transform.position = Input.mousePosition;
        Draggable temp = gameObject.GetComponent<Draggable>();
        
        DragDropManager.instance.BeingDragged(temp);
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OnDrag.Invoke();
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OnDrop.Invoke();
        GetComponent<Image>().raycastTarget = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnDragStart.Invoke();
        GetComponent<Image>().raycastTarget = false;
    }
}
