using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAnchor : MonoBehaviour
{
    public delegate void AddAnchor(HealthAnchor _anchorref);
    public static event AddAnchor OnAddAnchor;

    [SerializeField]
    HealthCanvas HEALTHCANVAS;

    [SerializeField]
    HealthBar _myhealth;
    // Start is called before the first frame update
    void Start()
    {
        if(HEALTHCANVAS == null)
        {
            HEALTHCANVAS = GameObject.FindObjectOfType<HealthCanvas>();
        }
        HEALTHCANVAS.AddAnchor(this);
    }

    public void SetHealth(HealthBar reference_to_Health_Canvas_Health_Bar)
    {
        _myhealth = reference_to_Health_Canvas_Health_Bar;

    }

    public HealthBar GetHealthBar()
    {
       
        return _myhealth;
    }
    public Vector3 GetPosition()
    {
        //Debug.Log(transform.position);
        return transform.position;
    }
}
