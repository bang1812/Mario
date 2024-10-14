using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPoint : MonoBehaviour
{
    public int scorenumber;
    public Text point;
    
    void Update()
    {
        point.text = "" + scorenumber * 10;
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
        
    }
}
