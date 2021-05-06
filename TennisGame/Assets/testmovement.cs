using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v  = Input.GetAxisRaw("Vertical");
    }
}
