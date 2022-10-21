using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

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
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
            
        }
        //normalize to make sure how ever close u are doesnt affect how fast your moving, so to move in a constant speed
         transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {
        Debug.Log("I am shooting ");
    }
    
}
