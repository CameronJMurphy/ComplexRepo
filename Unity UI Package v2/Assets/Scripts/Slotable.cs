using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slotable : MonoBehaviour
{
    public UnityEvent OnHover;
    public UnityEvent OnSlotted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        OnHover.Invoke();
    }
    private void OnMouseUp()
    {
        OnSlotted.Invoke();
    }
}
