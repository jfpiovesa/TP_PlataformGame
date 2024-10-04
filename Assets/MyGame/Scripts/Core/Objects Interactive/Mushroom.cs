using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : InteractiveObjectBase
{
    public float bounceForce = 10f;

    public override void ActionOnCollisionEnter2D(Collision2D collision)
    {
        base.ActionOnCollisionEnter2D(collision);

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

            playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
