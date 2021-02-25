using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    float force = 13;
    bool hitting;

    Animator animator;
    public Transform Ball;

    Vector3 aimmTargetInitalPosition;
    public Renderer rend;

    ShotManager shotManager;
    shot currentShot;

    private void Start() {
        rend =  GetComponent<Renderer>();
        rend.enabled = false;
        animator = GetComponent<Animator>();
        aimmTargetInitalPosition= aimTarget.position;

        shotManager = GetComponent<ShotManager>();
        currentShot = shotManager.topSpin;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v  = Input.GetAxisRaw("Vertical");


        if(Input.GetKeyDown(KeyCode.F)){
            hitting=true;
            currentShot=shotManager.topSpin;
        } else if(Input.GetKeyUp(KeyCode.F)){
            hitting = false;
        }


   if(Input.GetKeyDown(KeyCode.Q)){
            currentShot=shotManager.flat;

        } else if(Input.GetKeyUp(KeyCode.Q)){
            hitting = false;
        }


        if(hitting){
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * 2 * Time.deltaTime);
        }

        if((h != 0 || v != 0) && !hitting){
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")){
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0,currentShot.upforce,0);
            Vector3 ballDir = Ball.position - transform.position;
            if(ballDir.x >= 0){
            animator.Play("forehand");
            
            } else {
            animator.Play("backhand");
            Debug.Log("backhand");

            }

            aimTarget.position = aimmTargetInitalPosition;
        }

    }

}
