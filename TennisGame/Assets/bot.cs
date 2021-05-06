using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public float speed=10f;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;
    public Transform[] targets;
    Vector3 targetPosition;
    public AudioSource m_MyAudioSource;

    ShotManager shotManager;
    // Start is called before the first frame update
    void Start()
    {
        //the bot's target position is his own position at the start
        /*
        Then we change the target x position to be the ball's x position 
        and we move him there
        */
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
        shotManager = GetComponent<ShotManager>();
    }

    // Update is called once per frame
    void Update()
    {
     Move();   
    }

    void Move(){
        targetPosition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    Vector3 PickTarget(){
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }

    Shot PickShot(){
        float randomUpForce = Random.Range(3f,6f);
        float randomHitForce = Random.Range(15f,20f);
        Shot BotServe = new Shot(randomUpForce, randomHitForce);
      //  Debug.Log("This hit is:" + "("+BotServe.upforce+ ", " + BotServe.hitforce + ")");
        return BotServe;
        
    }

    private void OnTriggerEnter(Collider other) {
        Shot currentShot = PickShot();
        if(other.CompareTag("Ball")){
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0,currentShot.upforce,0);
            Vector3 ballDir = ball.position - transform.position;
            m_MyAudioSource.Play();

                if(ballDir.x >= 0){
                animator.Play("forehand");              
                } else {
                animator.Play("backhand");
                }

                ball.GetComponent<Ball>().hitter = "bot";

            }

    }

}
