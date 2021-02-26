using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    bool hitting;

    Animator animator;
    public Transform Ball;

    Vector3 aimmTargetInitalPosition;
    public Renderer rend;

    ShotManager shotManager;
    Shot currentShot;

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
        } else if(Input.GetKeyUp(KeyCode.F)){
            hitting = false;
        }
        if(hitting){
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * 2 * Time.deltaTime);
        }

        if((h != 0 || v != 0) && !hitting){
            transform.Translate(new Vector3(h, 0, v) * speed *  2 * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.L)){
            currentShot=shotManager.topSpin;
        } else if(Input.GetKeyUp(KeyCode.L)){
            hitting = false;
        }


   if(Input.GetKeyDown(KeyCode.K)){

            currentShot=shotManager.flat;

        } else if(Input.GetKeyUp(KeyCode.K)){
            hitting = false;
        }


        
        if(Input.GetKeyDown(KeyCode.I)){
            currentShot=shotManager.flatServe;
            GetComponent<BoxCollider>().enabled = false;
            animator.Play("serve-prepare");
        }

        if(Input.GetKeyDown(KeyCode.O)){
            currentShot=shotManager.kickServe;
            GetComponent<BoxCollider>().enabled = false;
            animator.Play("serve-prepare");
        }  
        
        if(Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.O)){
            hitting = false;
            GetComponent<BoxCollider>().enabled = true;
            Ball.transform.position = transform.position + new Vector3(0.2f, 1, 1);
            Vector3 dir = aimTarget.position - transform.position;
            Ball.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0,currentShot.upforce,0);
            animator.Play("serve");
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
