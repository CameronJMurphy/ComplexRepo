using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCon : MonoBehaviour
{
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        DragDropEvents.instance.onDrop += OnDropped;
        id = gameObject.GetInstanceID();
    }

    private void OnDropped(int id)
    {
        if (id == this.id)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private void OnDestroy()
    {
        DragDropEvents.instance.onDrop -= OnDropped;
    }
}
