using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TweenType
{
    Single,
    PingPong,
    Looping
}

public enum Curve
{
    linear,
    Quadratic,
    Cubic
}

public enum TransformSection
{
    position,
    scale
}

public class TweenTransform : MonoBehaviour
{
    public TransformSection affectedSection;
    public TweenType tweenType;
    public Curve curve;
    public float duration;
    public Vector3 startVector;
    public Vector3 endVector;
    public bool startVectorEqualsPosition = false;
    public bool loop = false;

    int points = 50;
    Vector3[] speeds = new Vector3[50];
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(startVectorEqualsPosition)
        {
            startVector = transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Invoke()
    {
        switch (curve) //which curve type is it
        {
            case (Curve.Cubic):
                CurveCubic();
                break;
            case (Curve.linear):
                CurveLinear();
                break;
            case (Curve.Quadratic):
                CurveQuadratic();
                break;
        }
        switch (affectedSection)
        {
            case TransformSection.position:
                TweenPosition();
                break;
            case TransformSection.scale:
                TweenScale();
                break;
        }
    }

    void TweenPosition()
    {

        switch (tweenType) //which tween type is it
        {

            case (TweenType.Looping):
                //continuous
                StartCoroutine(LoopingTween());
                break;
            case (TweenType.PingPong):
                StartCoroutine(PingPongTween());
                //backforth
                break;
            case (TweenType.Single):
                //one time
                StartCoroutine(SingleTween());
                break;
        }
    }

    void TweenScale()
    {
        switch (curve) //which tween type is it
        {
            case (Curve.Cubic):
                break;
            case (Curve.linear):
                break;
            case (Curve.Quadratic):
                break;
        }
    }
    ////////////TweensTypes/////////////////
    IEnumerator LoopingTween()
    {
        //get to end of tween
        //go back to start
        //repeat
        while (loop == true)
        {
            if (affectedSection == TransformSection.position)
            {
                float elapsedTime = 0;
                while (elapsedTime < duration)
                {
                    transform.localPosition = Vector3.Lerp(startVector, endVector, elapsedTime / (duration / 2));
                    if (transform.localPosition == endVector)
                    {
                        transform.localPosition = startVector;
                    }
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                yield return null;
            }
        }

        if (loop != true)
        {
            for (int i = 0; i < 2; ++i)
            {
                if (affectedSection == TransformSection.position)
                {
                    float elapsedTime = 0;
                    while (elapsedTime < duration)
                    {
                        transform.localPosition = Vector3.Lerp(startVector, endVector, elapsedTime / (duration / 2));
                        if (transform.localPosition == endVector)
                        {
                            transform.localPosition = startVector;
                        }
                        elapsedTime += Time.deltaTime;
                        yield return new WaitForEndOfFrame();
                    }
                    yield return null;
                }
            }

        }
    }

    IEnumerator PingPongTween()
    {
        //reach the end of the tween
        //Go from back to front
        //repeat
        while (loop == true)
        {
            if (affectedSection == TransformSection.position)
            {
                float elapsedTime = 0;
                float timer2 = 0;
                while (elapsedTime < duration)
                {
                    if (transform.localPosition != endVector)
                    {
                        transform.localPosition = Vector3.Lerp(startVector, endVector, elapsedTime / (duration / 2));
                    }
                    if (transform.localPosition == endVector)
                    {
                        transform.localPosition = Vector3.Lerp(endVector, startVector, timer2 / (duration / 2));
                        timer2 += Time.deltaTime;
                    }
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                //transform.localPosition = endVector;
                yield return null;
            }
        }

        if (loop != true)
        {
            if (affectedSection == TransformSection.position)
            {
                float elapsedTime = 0;
                float timer2 = 0;
                while (elapsedTime < duration)
                {
                    if (transform.localPosition != endVector)
                    {
                        transform.localPosition = Vector3.Lerp(startVector, endVector, elapsedTime / (duration / 2));
                    }
                    if (transform.localPosition == endVector)
                    {
                        transform.localPosition = Vector3.Lerp(endVector, startVector, timer2 / (duration / 2));
                        timer2 += Time.deltaTime;
                    }
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                //transform.localPosition = endVector;
                yield return null;
            }
        }
        
    }

    IEnumerator SingleTween()
    {
        //Reach end of tween
        //stop
        if (affectedSection == TransformSection.position)
        {
            float elapsedTime = 0;
            while (elapsedTime < duration)
            {
                transform.localPosition = Vector3.Lerp(startVector, endVector, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.localPosition = endVector;
            yield return null;
        }
      

    }

    ////////////Curves/////////////////
    void CurveLinear()
    {
        for (int i = 1; i < points + 1; ++i)
        {
            float t = i / points;
            speeds[i - 1] = startVector + t * (endVector - startVector);
        }
    }

    void CurveCubic()
    {
        for (int i = 1; i < points + 1; ++i)
        {
            float t = i / points;
            speeds[i - 1] = CalculatePointOnCubicCurve(t, startVector, endVector / 3, (endVector / 3) * 2, endVector);
        }
    }
    Vector3 CalculatePointOnCubicCurve(float t, Vector3 start, Vector3 intermediary, Vector3 intermediary2, Vector3 end)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;
        return uuu * start + 3 * uu * t * intermediary + 3 * u * tt * intermediary2 + ttt * end;
    }

    void CurveQuadratic()
    {
        for (int i = 1; i < points + 1; ++i)
        {
            float t = i / points;
            speeds[i - 1] = CalculatePointOnQudracticCurve(t, startVector, endVector, endVector / 2);
        }
    }
    Vector3 CalculatePointOnQudracticCurve(float t, Vector3 start, Vector3 intermediary, Vector3 end)
    {
        float o = 1 - t;
        float tt = t * t;
        float oo = o * o;
        return (00 * start) + (2 * o * t * intermediary) + (tt * end);
    }

}
