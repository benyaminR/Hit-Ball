using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private Vector3 touch;
    private Vector3 release;
    
    //releaseTime - touchTime = dragTime
    //the speed of ball is depended on dragTime
    private float touchTime;
    private float releaseTime;

    private float time;
    public float fireRate = 0.5f;

    public Text scoreText;
    public Text ballsText;
    public Text lvlText;
    private float nextThrow;

    public GameObject[] lvls;
    public GameObject ball;
    //where to drop the balls
    public Vector3 dropPoint = new Vector3(0,7,-6);

    //whether the first ball is instantiated
    private bool firstBallInstantiated = false;

    private GameObject instantiatedBall;

    private  int balls = 3;
    private int score;
    private int lvl;


    private bool alreadyCheck;

    // Start is called before the first frame update
    void Start()
    {

        score = PlayerPrefs.GetInt("score");
        lvl = PlayerPrefs.GetInt("lvl");
        scoreText.text = "score:"+score;
        lvlText.text = "level:"+lvl;


        switch(lvl){
            case 1 : 
            Instantiate(lvls[0]);
            return;
            case 2:
            Instantiate(lvls[1]);
            return;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    //instantiate the first ball
    if(!firstBallInstantiated){
        instantiatedBall = Instantiate(ball,dropPoint,Quaternion.identity);
        firstBallInstantiated = true;
    }

     //if pressed down(first touch)
    if(Input.GetButtonDown("Fire1")&&Time.time > nextThrow && balls >0){
		nextThrow = Time.time + fireRate;
        touchTime = Time.time;      
        touch = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

    }
    //fire the ball and instantiate another one
    if(Input.GetButtonUp("Fire1")&& balls >0){
        release = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        releaseTime = Time.time;
        float dragTime = releaseTime - touchTime;//dragTime        
        instantiatedBall.GetComponent<Shoot>().fire(touch,release,dragTime);
        instantiatedBall = Instantiate(ball,dropPoint,Quaternion.identity);
        balls--; // reduce balls
        ballsText.text = "Balls:"+balls;
    }
    
    if(balls <= 0){
        Debug.Log("GAMEOVER BITCH");
        }

    //check game state
    if(!alreadyCheck)
    updateGameState();

    
    }
    public void addScore(){
        Debug.Log("Goal!!!!");
        score += 1; 
        scoreText.text = "Score:"+score;

    }

    public void addBall(){
        balls++;
        ballsText.text = "Balls:"+balls;
    }


    public void updateGameState(){
        
        if(GameObject.FindGameObjectsWithTag("RedCan").Length == 0 && 
            GameObject.FindGameObjectsWithTag("GreenCan").Length == 0 &&
            GameObject.FindGameObjectsWithTag("YellowCan").Length == 0)
            {
            alreadyCheck = true;
            lvl++;                          //lvl up
            PlayerPrefs.SetInt("lvl",lvl);
            PlayerPrefs.SetInt("score",score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("StartScene");        
        }

    }

}
