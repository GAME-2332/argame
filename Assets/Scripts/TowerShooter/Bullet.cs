using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    private Transform target;
    
    
    [Header("Audio")]
    public AudioClip audioSFX;
    
    
    [Header("Values")]
    public int Bulletdamage = 5;
    public float speed = 70f;
    
    public GameObject impactFX;

    public void Seek(Transform _target){
        target = _target;
    }
    
    
    void Update() {
        if (target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //dir( direction) magnitude  is the current distance to the target, if its less than this frame, you hit the object
        if (dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
            
        }
        //normalize to make sure how ever close u are doesnt affect how fast your moving, so to move in a constant speed
         transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        GameObject effectIns = (GameObject)Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        AudioSource.PlayClipAtPoint(audioSFX, transform.position);
        //The bullet looks for a component that has the enemy script, finds a method for taking damage (could be anything you call it ex. enemyDamage etc.
        if (target.GetComponent<Enemy>()){
            target.GetComponent<Enemy>().TakeDamage(Bulletdamage);
        }
        //This destroys the bullet
        Destroy(gameObject);
        
    }
    

}
