using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Drag drop manager

///manager tracks when i mouse down over a draggable
///it then keeps track of the draggables container
///when i hover a slot, it tells the manager that we are hovering and sends the slot game object to the manager
///if i mouse up then the draggable gets parented to the slot.
///the manager tell new container to add this item
///then the manager tell the previous container to remove that item
/// </summary>
public class DragDropManager : MonoBehaviour
{
    public static DragDropManager instance;
    Draggable beingDragged = null;
    bool hoveringSlot = false;
    Slot slotBeingHovered = null;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Release();
        }
    }


    public void BeingDragged(Draggable item)
    {
        beingDragged = item;
    }

    public void HoveringSlot(bool answer, Slot slot)
    {
        hoveringSlot = answer;
        slotBeingHovered = slot;
    }

    private void Release()
    {
        if (hoveringSlot && beingDragged != null)
        {
            if (!slotBeingHovered.HasItem())
            {
                slotBeingHovered.AddItem(beingDragged);
                beingDragged.GetComponentInParent<Slot>().RemoveItem();
                beingDragged.transform.SetParent(slotBeingHovered.transform);
            }
            Reset();
        }
        else {
            Reset();
        }
    }

    private void Reset()
    {
        if (beingDragged)
        {
            beingDragged.transform.localPosition = new Vector3(0, 0, 0);
            beingDragged = null;
        }
        hoveringSlot = false;
        slotBeingHovered = null;  
    }
}
