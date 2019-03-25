using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 10f;
    public float directionMagnifer = 15f;

    private bool shouldFire;

    public float speedLimit;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFire){
            GetComponent<Rigidbody>().AddForce(direction,ForceMode.Impulse);
            shouldFire = !shouldFire;
        }
    }
    public void fire(Vector3 touch, Vector3 release,float dragTime){
        direction = directionMagnifer *(release-touch); 
        direction.z = speed / dragTime;                 //for smaller dragTimes the ball is faster
        direction.z = direction.z >= speedLimit ? speedLimit :direction.z;//if greater than speedLimit set speed to speedLimit                   
        Debug.Log("speed:"+speed/dragTime);
        Debug.Log("DragTime:"+dragTime);
        shouldFire = !shouldFire;
    }
}
