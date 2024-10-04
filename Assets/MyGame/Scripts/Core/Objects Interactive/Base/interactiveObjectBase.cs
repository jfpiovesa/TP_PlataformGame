using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectBase : MonoBehaviour
{
    [SerializeField] GameObject objectDestroyedPrefab;
    [SerializeField] bool canOnCollisionEnter2D = true;
    [SerializeField] bool canOnTriggerEnter2D = true;


    protected GameObject player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canOnCollisionEnter2D) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            ActionOnCollisionEnter2D(collision);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            ActionOnCollisionExit2D(collision);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canOnTriggerEnter2D) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            ActionOnTriggerEnter2D(collision);
        }
    }
    public virtual void ActionOnCollisionEnter2D(Collision2D collision)
    {

    }
    public virtual void ActionOnCollisionExit2D(Collision2D collision)
    {

    }
    public virtual void ActionOnTriggerEnter2D(Collider2D collision)
    {

    }
    public virtual void DestruirWithInstantiate()
    {
        Instantiate(objectDestroyedPrefab, transform.position, Quaternion.identity);
        Destroy();

    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
