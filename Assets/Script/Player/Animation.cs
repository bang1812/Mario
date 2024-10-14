using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GroundCheck check;
    public Animator animator;
    public Player player;
    

    
    void Update()
    {
        if (!player.die)
        {
            
            if (!check.groundCheck)
            {
                animator.Play("jump");
                return;
            }

            if (InputPlayer.instance.horizontal == 0)
            {

                animator.Play("idle");
                return;
            }


            animator.Play("run");
        }

        else
        {
            animator.Play("hit");
        }
        
    }
    


}
