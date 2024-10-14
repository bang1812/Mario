using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{
    public List<Transform> BoxTransform;

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.GetContact(0).normal == Vector2.down && col.gameObject.CompareTag("Box"))
        {
            
            IBoxRespond BoxRespond = col.gameObject.GetComponent<IBoxRespond>();
            BoxTransform.Add(col.transform);
            
        }
  
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (BoxTransform.Count != 0 && col.gameObject.CompareTag("Box"))
        {
            Transform min = BoxTransform[0];
            foreach (Transform t in BoxTransform)
            {
                if (Mathf.Abs(min.transform.position.x - transform.position.x) > Mathf.Abs(t.transform.position.x - transform.position.x))
                {
                    min = t;
                }
            }
            min.gameObject.GetComponent<IBoxRespond>().Respond();
            BoxTransform.Clear();
        }
        
        

    }
}
