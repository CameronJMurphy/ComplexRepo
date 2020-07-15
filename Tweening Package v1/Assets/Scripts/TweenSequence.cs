using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSequence : MonoBehaviour
{
    public List<TweenTransform> tweens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Invoke()
    {
        foreach(var tween in tweens)
        {
            tween.Invoke();
        }
    }
}
