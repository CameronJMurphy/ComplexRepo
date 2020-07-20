using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Container : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<Slot> slots;
    public UnityEvent OnHover;
    public UnityEvent OffHover;
    List<Container> containers;
    public int id = 0;

    private void Start()
    {
        slots = new List<Slot>(GetComponentsInChildren<Slot>());
        containers = new List<Container>(FindObjectsOfType<Container>());
        foreach(var container in containers)
        {
            if(container == this)
            {
                break;
            }
            ++id;
        }
    }

    public void UpdateList()
    {
        slots.RemoveRange(0, slots.Count);
        slots = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    public void ChangeColour(Container obj)
    {
        //Debug.Log(obj.gameObject.GetInstanceID());
        //if (obj.id == this.id)
        //{
        //    obj.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        //}
    }
    public void ChangeColourBack()
    {
        if (gameObject.GetComponent<Container>().id == id)
        {
            gameObject.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OffHover.Invoke();
    }
}
