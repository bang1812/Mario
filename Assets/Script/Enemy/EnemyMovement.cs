using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction = Vector2.left;


    void Update()
    {
        Vector2 move = new Vector2(direction.x * speed, rb.velocity.y);
        rb.velocity = move;
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground") || (gameObject.tag == "Enemy" && col.gameObject.CompareTag("Enemy")))
        {
            if(rb.velocity.y >= -0.2f)
                direction *= -1;
        }
    }
}
