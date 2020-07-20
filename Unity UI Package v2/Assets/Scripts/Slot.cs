using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public Draggable item = null;

    public UnityEvent OnHover;
    public UnityEvent OnSlot;


    private void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            OnHover.Invoke();
            DragDropManager.instance.HoveringSlot(true, GetComponent<Slot>());
        }
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
            return true;
        }
        return false;
    }

    public void RemoveItem()
    {
        item = null;
    }

    //bool ItemOver()
    //{
    //    out RaycastHit raycastHit;

    //}
}
