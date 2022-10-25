using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAnchor : MonoBehaviour
{
    [SerializeField]
    HealthCanvas HEALTHCANVAS;
    // Start is called before the first frame update
    void Start()
    {
        if(HEALTHCANVAS == null)
        {
            HEALTHCANVAS = GameObject.FindObjectOfType<HealthCanvas>();
        }
        HEALTHCANVAS.AddAnchor(this);

    }

    // Update is called once per frame
    void Update()
    {
       // SayPosition();
    }

    void SayPosition()
    {
        Debug.Log(transform.position);
    }

    public Vector3 GetPosition()
    {
        Debug.Log(transform.position);
        return transform.parent.position;
    }
}
