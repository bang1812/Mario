using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    
    public void FlipFace()
    {
        Vector3 curScale = transform.localScale;
        if (InputPlayer.instance.horizontal < 0)
        {
            //curScale.x = -Mathf.Abs(curScale.x);
            spriteRenderer.flipX = true;
        }
        else if (InputPlayer.instance.horizontal > 0)
        {
            //curScale.x = Mathf.Abs(curScale.x);
            spriteRenderer.flipX = false;
        }
        
        transform.localScale = curScale;
    }
    void Update()
    {
        FlipFace();
    }
}
