using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ani : MonoBehaviour
   {     Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("f_idle_A");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
