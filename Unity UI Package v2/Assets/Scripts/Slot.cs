using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Draggable item = null;

    public UnityEvent OnHover;
    public UnityEvent OnSlot;

    private void Start()
    {
        item = GetComponentInChildren<Draggable>();
    }

    public bool HasItem()
    {
        return item != null;
    }

    public bool AddItem(Draggable _item)
    {
        if (!HasItem())
        {
            item = _item;
            OnSlot.Invoke();
            return true;
        }
        return false;
    }

    public void RemoveItem()
    {
        item = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover.Invoke();
        DragDropManager.instance.HoveringSlot(true, gameObject.GetComponent<Slot>());        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DragDropManager.instance.HoveringSlot(false, gameObject.GetComponent<Slot>());
    }
}
