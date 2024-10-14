using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipFace : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    
    void Update()
    {
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
