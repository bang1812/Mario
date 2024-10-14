using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float bounce;
    public Vector2 direct;

    public void Move()
    {
        rb.AddForce(direct * speed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[col.contactCount];
        if (col.GetContacts(contacts) > 1)
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Box") || col.gameObject.CompareTag("Obstacle"))
        {
            if (col.GetContact(0).normal == Vector2.up)
            {
                rb.velocity = Vector2.zero;
                if(direct.x < 0)
                {
                    rb.AddForce(new Vector2(-1, 1).normalized * bounce, ForceMode2D.Impulse);
                    return;
                }
                else if (direct.x > 0)
                {
                    rb.AddForce(new Vector2(1, 1).normalized * bounce, ForceMode2D.Impulse);
                    return;
                }
                
            }
            
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }
}
