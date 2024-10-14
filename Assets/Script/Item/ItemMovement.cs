using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    private void Update()
    {
        StartCoroutine(DelayMove());
        
        
    }
    
    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(1);
        Vector2 curdir = new Vector2(direction.x * speed, rb.velocity.y);
        rb.velocity = curdir;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            direction *= -1;
        }
    }

}
