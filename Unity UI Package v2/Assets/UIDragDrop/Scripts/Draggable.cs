using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	#region Variables
	public UnityEvent OnDrag;
    public UnityEvent OnDrop;
    public UnityEvent OnFailDrop;
    public UnityEvent OnDragStart;
    private ContainerType containerType;

    [HideInInspector]
    public int editorIndex;
    [HideInInspector]
    public Slot parent;
    [HideInInspector]
    public string itemType;
    [HideInInspector]
    public Container container;

	#endregion

	#region Methods

	void Start()
    {
        OnDrag.AddListener(Drag);
        container = GetComponentInParent<Container>();
    }


	void IDragHandler.OnDrag(PointerEventData eventData)
    {
       OnDrag.Invoke();  
    }

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = GetComponentInParent<Slot>();
        containerType = GetComponentInParent<Container>().containerType;
        container = GetComponentInParent<Container>();

        gameObject.transform.parent = gameObject.transform.root;
        OnDragStart.Invoke();
        GetComponent<Image>().raycastTarget = false;
        
    }

	public void Drag()
    {

        gameObject.transform.position = Input.mousePosition;
        Draggable temp = gameObject.GetComponent<Draggable>();

        DragDropManager.instance.BeingDragged(temp);
    }

	public void OnDropFail()
    {
        OnFailDrop.Invoke();
        transform.parent = parent.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        Debug.Log("Drop Failed");
    }

    public void OnSuccessfulDrop()
	{
        OnDrop.Invoke();
    }
	#endregion
}
