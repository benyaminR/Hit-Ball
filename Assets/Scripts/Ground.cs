using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float destroyTime = 3.0f;
    public GameObject controller;
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.layer== 11){
            Destroy(collision.gameObject,destroyTime);
            switch(collision.gameObject.tag){
                case "YellowCan":
                Debug.Log("YellowCan hit the Ground");
                controller.GetComponent<GameController>().addScore();
                return;
                case "GreenCan":
                Debug.Log("GreenCan hit the Ground");
                controller.GetComponent<GameController>().addBall();
                return;
                case "RedCan":
                Debug.Log("RedCan hit the Ground");
                return;
            }
        }
    }
}
