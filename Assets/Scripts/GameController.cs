using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Vector3 touch;
    private Vector3 release;
    
    private float time;
    public float fireRate = 0.5f;

    private float nextThrow;

    public GameObject ball;
    //where to drop the balls
    public Vector3 dropPoint = new Vector3(0,7,-6);

    //whether the first ball is instantiated
    private bool firstBallInstantiated = false;

    private GameObject instantiatedBall;

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
        touch = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        Debug.Log("ButtonDown!");

    }
    //fire the ball and instantiate another one
    if(Input.GetButtonUp("Fire1")){
        release = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        instantiatedBall.GetComponent<Shoot>().fire(touch,release);
        instantiatedBall = Instantiate(ball,dropPoint,Quaternion.identity);
        Debug.Log("ButtonUp!");
    }
    
    
    }
}
