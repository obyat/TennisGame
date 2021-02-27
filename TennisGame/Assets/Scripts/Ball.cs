using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField] Text playerScoreText;
    [SerializeField] Text botScoreText;

    Vector3 initalPos;
    public string hitter;
    int playerScore = 0;
    int botScore = 0;

    public bool playing = true;

    // Start is called before the first frame update
    void Start()
    {
        initalPos = transform.position;
        updateScores();
    }
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Wall")){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("player").GetComponent<Player>().Reset();
            if (playing){
                if(hitter == "player"){
                    playerScore++;
                } else if(hitter == "bot") {
                    botScore++;
                }
                playing = false;
                updateScores();
            }
        } else if(collision.transform.CompareTag("out")){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("player").GetComponent<Player>().Reset();
            if (playing){
                if(hitter == "player"){
                    playerScore++;
                } else if(hitter == "bot") {
                    botScore++;
                }
                playing = false;
                updateScores();
            }
        
        }




    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("out") && playing) {
                if(hitter == "player"){
                playerScore++;
            } else if(hitter == "bot") {
                botScore++;
        }
        playing = false;
        updateScores();
        }
    }

    private void updateScores(){
        playerScoreText.text = "Player: " + playerScore;
        botScoreText.text = "Enemy: " + botScore;
    }

}
