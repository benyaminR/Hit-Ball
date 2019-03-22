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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //if pressed down(first touch)
    if(Input.GetButtonDown("Fire1")&&Time.time > nextThrow){
		nextThrow = Time.time + fireRate;        
        touch = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        Debug.Log("ButtonDown!");

    }

    if(Input.GetButtonUp("Fire1")){
        release = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        //user touch as inistantiation location
        //instantiate ball        
        GameObject instantiatedBall = Instantiate(ball,release,Quaternion.identity);
        //call fire
        instantiatedBall.GetComponent<Shoot>().fire(touch,release);
        Debug.Log("ButtonUp!");
    }
    
    }
}
