using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool groundCheck;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Box") || col.CompareTag("Shalf"))
        {
            groundCheck = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Box") || col.CompareTag("Shalf"))
        {
            groundCheck = false;
        }
    }
}
