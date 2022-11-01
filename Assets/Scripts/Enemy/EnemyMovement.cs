using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform m_transform;
    [SerializeField]
    Transform destination;
    [SerializeField]
    int time;
    [SerializeField]
    float elapsedtime;
    float percentage;
    bool CanMove;
    // Start is called before the first frame update
    void Start()
    {
        if(destination != null)
        {
            CanMove = true;
        }

        if(destination == null)
        {
            FindPlayer();
        }
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        SetDestination(player.transform);
    }

    public void SetDestination(Transform newdestination)
    {
        destination = newdestination;
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (destination == null)
        {
            CanMove = false;
        }
        if(CanMove == true)
        {
            elapsedtime += Time.deltaTime;
            percentage = elapsedtime / (float)time;
            m_transform.position = Vector3.Lerp(m_transform.position, destination.position, percentage);
        }
        else
        {
            m_transform.position = finallocation;
            m_transform.rotation = finalrotation;
        }
      
    }

    [SerializeField]
    Vector3 finallocation;
    Quaternion finalrotation;
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            CanMove = false;
            finallocation = m_transform.position;
            finalrotation = m_transform.rotation;
        }
       
    }
}
