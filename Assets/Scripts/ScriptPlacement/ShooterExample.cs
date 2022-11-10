using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterExample : MonoBehaviour
{

    public GameObject projectilePrefab;
    public GameObject _enemy;
    
    public float throwForce = 5f;
    public int _bulletDamage = 2;
    
    
     void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Im pressed");
            GameObject projectileGO = (GameObject) Instantiate(projectilePrefab, transform.position, 
                projectilePrefab.transform.rotation);

            Rigidbody projectileRb = projectileGO.GetComponent<Rigidbody>();
            projectileRb.AddForce(throwForce * Vector3.forward, ForceMode.Impulse);
            
            if (_enemy.GetComponent<TestEnemy>()) {
                _enemy.GetComponent<TestEnemy>().TakeDamage(_bulletDamage);
                Destroy(projectileGO, 1f);
            }
        }
    }
}
