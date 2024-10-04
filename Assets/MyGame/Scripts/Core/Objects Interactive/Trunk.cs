using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : InteractiveObjectBase
{

    public float sinkSpeed = 0.5f;  
    public float maxSinkDepth = -1f;  
    public float riseSpeed = 0.5f;  
    private Vector3 initialPosition; 
    private Coroutine sinkingCoroutine = null;

    int randomSinkLog = 0;


    private void OnEnable()
    {
        initialPosition = transform.position;
        randomSinkLog = Random.Range(0, 100); 
    }
    public override void ActionOnCollisionEnter2D(Collision2D collision)
    {
        base.ActionOnCollisionEnter2D(collision);

        if (randomSinkLog < 20 ) return;

        if (sinkingCoroutine == null)
        {
            sinkingCoroutine = StartCoroutine(SinkLog());
        }

    }
    public override void ActionOnCollisionExit2D(Collision2D collision)
    {
        base.ActionOnCollisionExit2D(collision);

        if (randomSinkLog < 20) return;

        if (sinkingCoroutine != null)
        {
            StopCoroutine(sinkingCoroutine);
            sinkingCoroutine = null;
             StartCoroutine(RaiseLog());
        }

    }
    IEnumerator SinkLog()
    {
        while (transform.position.y > maxSinkDepth)
        {
            transform.position += Vector3.down * sinkSpeed * Time.deltaTime;
            yield return null; 
        }
    }
    IEnumerator RaiseLog()
    {
        while (transform.position.y < initialPosition.y)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
