using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerBeach : MonoBehaviour
{
    public float startTimer;
    public GameObject[] startText;
    public bool startGame;

    public Text qualifiedText;
    public int qualifiedNum;
    public int totalEnemies;

    public ParticleSystem portal;
    public bool hasEntered;

    public GameObject winText;
    public GameObject loseText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        startTimer = 6f;
        startGame = true;
        hasEntered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((int) startTimer > 4){
            // On "Start in" screen
        } else if((int) startTimer == 4){
            Destroy(startText[0]);
            startText[1].SetActive(true);
        } else if((int) startTimer == 3){
            Destroy(startText[1]);
            startText[2].SetActive(true);
        } else if((int) startTimer == 2){
            Destroy(startText[2]);
            startText[3].SetActive(true);
        } else if((int) startTimer == 1){
            Destroy(startText[3]);
            startText[4].SetActive(true);
        }
        else if (startGame)
        {
            Time.timeScale = 1;
            Destroy(startText[4]);
            startGame = false;
        }
        startTimer -= .0024f;
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player") && !hasEntered){
    //         qualifiedNum++;
    //         qualifiedText.text = qualifiedNum + " / " + totalEnemies;
    //         hasEntered = true;
    //         // Vector3 pos = other.transform.position;
    //         // pos.x += 1;
    //         // pos.y += 3; 
    //         // pos.z += 4;
    //         Vector3 pos = other.transform.position;
    //         pos.y += 3; 
    //         pos.z += 4;
    //         GameObject won = Instantiate(winText, pos, Quaternion.identity);
    //     }
    //     if(other.CompareTag("bots")&&!hasEntered){
    //         qualifiedNum++;
    //         qualifiedText.text = qualifiedNum + " / 1";
    //         hasEntered = true;
    //         Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
    //         pos.y += 3; 
    //         GameObject lost = Instantiate(loseText, pos, Quaternion.identity);
    //     }
    // }
}
