using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class HealthCanvas : MonoBehaviour
{
    [SerializeField]
    List<HealthAnchor> _anchors;

    [SerializeField]
    GameObject _target;


    float screen_width;
    float screen_height;

    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _anchors = new List<HealthAnchor>();
        if(_cam == null)
        {
            _cam = GameObject.FindObjectOfType<Camera>();
        }

        screen_width = _cam.pixelWidth;
        screen_height = _cam.pixelHeight;
    }

    public void AddAnchor(HealthAnchor _ha)
    {
        if(_anchors == null)
        {
            _anchors = new List<HealthAnchor>();
        }
        _anchors.Add(_ha);
    }

    [SerializeField]
    HealthAnchor _anchor;

    // Update is called once per frame
    void Update()
    {
        Get2DPosition(_anchor);
    }
    [SerializeField]
    Vector2 camscreen;
    void Get2DPosition(HealthAnchor _anchor)
    {
       //Debug.Log("Screen point:" + _cam.WorldToScreenPoint(_anchor.GetPosition()) );

        float x = _cam.WorldToViewportPoint(_anchor.GetPosition()).x; //how many pixels it is from the left. 
        float y = _cam.WorldToViewportPoint(_anchor.GetPosition()).y;
       
        //x = x * screen_width;
        // y = y * screen_height;

        Vector2 middle = new Vector2(0.5f, 0.5f);
        Vector2 location = new Vector2(x,y) - middle;
        float new_x = location.x * screen_width;
        float new_y = location.y * screen_height;
        camscreen = new Vector2(new_x, new_y);

        //_target.GetComponent<RectTransform>().localPosition = _cam.WorldToScreenPoint(_anchor.GetPosition());
        _target.GetComponent<RectTransform>().localPosition = camscreen;

        Ray _ray = _cam.ViewportPointToRay(_anchor.GetPosition());


    }
}
