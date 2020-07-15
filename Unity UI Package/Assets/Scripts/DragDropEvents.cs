using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;



[System.Serializable]
public class DragDropEvents : UnityEvent
{
    public static DragDropEvents instance;
   
    public UnityEvent unityEvent;
    //public UnityEvent OnDrop;
    //public UnityEvent OnFailDrop;
    //public UnityEvent OnDragOverContainer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
    ////ON DROP
    //public event Action<int> onDrop;
    //public void OnDrop(int id)
    //{
    //    if(onDrop != null)
    //    {
    //        onDrop(id);
    //    }
    //}
    ////ON FAIL DROP
    //public event Action<int> onFailDrop;
    //public void OnFailDrop(int id)
    //{
    //    if (onFailDrop != null)
    //    {
    //        onFailDrop(id);
    //    }
    //}
    ////ON DRAG OVER
    //public event Action<int> onDragOver;
    //public void OnDragOver(int id)
    //{
    //    if (onDragOver != null)
    //    {
    //        onDragOver(id);
    //    }
    //}
    ////ON DRAG OVER CONTAINER
    //public event Action<int> onDragOverContainer;
    //public void OnDragOverContainer(int id)
    //{
    //    if (onDragOverContainer != null)
    //    {
    //        onDragOverContainer(id);
    //    }
    //}
    ////ON DRAG
    //public event Action<int> onDrag;
    //public void OnDrag(int id)
    //{
    //    if (onDrag != null)
    //    {
    //        onDrag(id);
    //    }
    //}

    //public event Action<int> onMouseDown;
    //public void OnMouseDown(int id)
    //{
    //    if (onMouseDown != null)
    //    {
    //        onMouseDown(id);
    //    }
    //}



}
