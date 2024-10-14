using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 direct = Vector2.up;
    
    
    void FixedUpdate()
    {

        rb.velocity = new Vector2(0, direct.y * speed);
        if (transform.localPosition.y <= -0.6)
        {
            direct.y = Mathf.Abs(direct.y);

        }
        else if (transform.localPosition.y >= 2)
        {
            direct.y = -Mathf.Abs(direct.y);

        }

    }
    
    
}
