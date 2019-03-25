using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCan : MonoBehaviour
{
    public GameObject controller;
    private bool alreadyAdded;
    void OnCollisionEnter(Collision collision){
        //add a ball if collided with a ball
        if(collision.gameObject.layer == 10 && !alreadyAdded){
            controller.GetComponent<GameController>().addBall();
            alreadyAdded = true;
        }
        //destroy if hit the ground
        if(collision.gameObject.layer == 9){
            Destroy(gameObject,3f);
        }
    }
}
