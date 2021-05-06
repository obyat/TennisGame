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
    public int maxScore;
    int botScore = 0;
    public GameObject stars;
    public AudioSource PAudioSource;
    public AudioSource BotAudioSource;
    private Vector3 sightcubepos;
    private GameObject sightcube;
    public bool playing = true;

    // Start is called before the first frame update
    void Start()
    {
        initalPos = transform.position;
        updateScores();
        sightcube = GameObject.FindWithTag("starcube");
        GetBoxPos();
    }
        public Vector3 GetBoxPos(){
            Vector3 playpos = sightcube.transform.position;

            Vector3 finalcube= new Vector3(playpos.x, playpos.y, playpos.z+5.5f);
        return finalcube;

    }

    void Update(){
        checkMaxScore();
        GetBoxPos();
    }
    
    private void OnCollisionEnter(Collision collision) {

            Vector3 currpos = GetBoxPos();
        if(collision.transform.CompareTag("Wall")){

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("player").GetComponent<Player>().Reset();
            if (playing){
                if(hitter == "player"){
                    playerScore++;
                    
                   Instantiate(stars, currpos, Quaternion.identity);
                   PAudioSource.Play();
                    Debug.Log("cube pos: "+ currpos);
 
                } else if(hitter == "bot") {
                    botScore++;
                    BotAudioSource.Play();
                }
                playing = false;
                updateScores();
                checkMaxScore();

            }
        } else if(collision.transform.CompareTag("out")){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("player").GetComponent<Player>().Reset();
            if (playing){
                if(hitter == "player"){
                    botScore++;
                    BotAudioSource.Play();
                } else if(hitter == "bot") {
                    playerScore++;
                    Debug.Log("cube pos: "+ currpos);
 
                   Instantiate(stars, currpos, Quaternion.identity);
//                   Instantiate(YOURWINOBJECT, currpos, Quaternion.identity);

                    PAudioSource.Play();
                }
                playing = false;
                updateScores();
                checkMaxScore();

            }
        
        }




    }

    private void checkMaxScore(){
        if (botScore == maxScore)
            Debug.Log("Bot Won");
        else if (playerScore == maxScore)
            Debug.Log("player Won");

    }


    private void updateScores(){
        playerScoreText.text = "Player: " + playerScore;
        botScoreText.text = "Enemy: " + botScore;
    }

}
