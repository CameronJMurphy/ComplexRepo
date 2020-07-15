using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private int id;
    private void Start()
    {
        id = gameObject.GetInstanceID();
    }


}
