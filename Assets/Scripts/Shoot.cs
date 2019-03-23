using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 10f;
    public float directionMagnifer = 15f;

    private bool shouldFire;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFire){
            GetComponent<Rigidbody>().velocity = direction;
            shouldFire = !shouldFire;
        }
    }

    public void fire(Vector3 touch, Vector3 release,float dragTime){
        direction = directionMagnifer *(release-touch);
        direction.z = speed / dragTime;
        Debug.Log("speed:"+speed/dragTime);
        Debug.Log("DragTime:"+dragTime);
        shouldFire = !shouldFire;
    }
}
