using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initalPos;
    // Start is called before the first frame update
    void Start()
    {
        initalPos = transform.position;
    }
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Wall")){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initalPos;
        }
    }
}
