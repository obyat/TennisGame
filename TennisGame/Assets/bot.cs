using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    float speed=50;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;
    float force = 13.1f;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
     Move() ;   
    }

    void Move(){
        targetPosition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")){
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0,5,0);
            Vector3 ballDir = ball.position - transform.position;
            if(ballDir.x >= 0){
            animator.Play("forehand");
              


              
            } else {
            animator.Play("backhand");
            Debug.Log("backhand");

            }
        }

    }

}
