using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private float nextThrow;

    public GameObject ball;
    //where to drop the balls
    public Vector3 dropPoint = new Vector3(0,7,-6);

    //whether the first ball is instantiated
    private bool firstBallInstantiated = false;

    private GameObject instantiatedBall;

    private static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
    if(Input.GetButtonDown("Fire1")&&Time.time > nextThrow){
		nextThrow = Time.time + fireRate;
        touchTime = Time.time;      
        touch = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

    }
    //fire the ball and instantiate another one
    if(Input.GetButtonUp("Fire1")){
        release = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        releaseTime = Time.time;
        float dragTime = releaseTime - touchTime;//dragTime        
        instantiatedBall.GetComponent<Shoot>().fire(touch,release,dragTime);
        instantiatedBall = Instantiate(ball,dropPoint,Quaternion.identity);
    }
    
    
    }

    public void addScore(){
        Debug.Log("Goal!!!!");
        score += 1; 
        scoreText.text = "Score:"+score;
    }
}
