using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCan : MonoBehaviour
{

    public float explosionForce = 4f;
    public float explosionRadius = 0.5f;

    public float upwardsModifier = 6f;
    private bool readyToDonate;

    void OnCollisionEnter(Collision collision){
        //if the incoming object is ball
        if(collision.gameObject.layer == 10){
            var colliders = Physics.OverlapSphere(transform.position,explosionRadius);
            foreach(Collider collider in colliders){
                //layer 11 ---> cans
                if(collider.gameObject.layer == 11){
                        collider.GetComponent<Rigidbody>().AddExplosionForce(
                    explosionForce: explosionForce,
                    explosionRadius:explosionRadius,
                    explosionPosition:collider.transform.position,
                    mode:ForceMode.Impulse,
                    upwardsModifier: upwardsModifier);
                }
            }
            Debug.Log("boom");
        }
        //hit ground
        if(collision.gameObject.layer == 9){
            Destroy(gameObject,3f);
        }
    }
}
