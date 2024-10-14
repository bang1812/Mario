using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float horizontal;
    public static InputPlayer instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

}
