using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    float force = 13;
    bool hitting;
  

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v  = Input.GetAxisRaw("Vertical");


        if(Input.GetKeyDown(KeyCode.F)){
            hitting=true;
        } else if(Input.GetKeyUp(KeyCode.F)){
            hitting = false;
        }

        if(hitting){
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);
        }

        if((h != 0 || v != 0) && !hitting){
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")){
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0,6,0);
        }
    }

}
