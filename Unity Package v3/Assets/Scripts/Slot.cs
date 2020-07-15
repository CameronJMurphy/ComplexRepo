using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    bool occupied = false;
    public Draggable item;

    public UnityEvent OnHover;
    public UnityEvent OnSlot;


    public void SetOccupied(bool answer)
    {
        occupied = answer;
    }
    public bool IsOccupied()
    {
        return occupied;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            OnHover.Invoke();
        }
    }

    //bool ItemOver()
    //{
    //    out RaycastHit raycastHit;

    //}
}
