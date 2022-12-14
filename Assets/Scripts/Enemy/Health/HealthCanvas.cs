using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class HealthCanvas : MonoBehaviour
{
    [SerializeField]
    List<HealthAnchor> _anchors;


    [SerializeField]
    List<RectTransform> _HealthBars; //on these targets spawn the health bars. Targets follow the anchors attached on the gameobject.

    [SerializeField]
    GameObject HealthBarPrefab;
   
    //[SerializeField]
    // GameObject _target;

    [SerializeField]
    float screen_width;
    [SerializeField]
    float screen_height;

    [SerializeField]
    Camera _cam;

    [SerializeField]
    HealthAnchor new_anchor;

    [SerializeField]
    int currentCount;
    // Start is called before the first frame update
    void Start()
    {
       // _anchors = new List<HealthAnchor>();

       // _HealthBars = new List<RectTransform>();
        if (_cam == null)
        {
            _cam = GameObject.FindObjectOfType<Camera>();
        }
        if(HealthBarPrefab == null)
        {
            HealthBarPrefab = Resources.Load<GameObject>("Prefabs/UI/HealthBar_Target");
        }
        
        SetSizes();
    }

    public void AddAnchor(HealthAnchor _ha)
    {
        currentCount++;
        
        _anchors.Add(_ha);
        new_anchor = _ha;
        CreateAHealthBar();
        _ha.SetHealth(_HealthBars[currentCount].GetComponent<HealthBar>());
       
    }

    [SerializeField]
    HealthAnchor _anchor;
    

    void CreateAHealthBar()
    {
        GameObject _newtarget = Instantiate(HealthBarPrefab, transform);
        _HealthBars.Add(_newtarget.GetComponent<RectTransform>());
    }
    // Update is called once per frame
    void Update()
    {
       if (_anchors.Count > 1)
        {
            //check if any enemies have died.
            bool SomeoneHasDied = false;


            for (int i = 1; i < _anchors.Count; i++)
            {
                if (_anchors[i] == null)
                {
                    SomeoneHasDied = true;
                    _anchors.RemoveAt(i);

                    GameObject.Destroy(_HealthBars[i].gameObject);
                    _HealthBars.RemoveAt(i);//this only removes the reference, you must destroy it too.
                    i--; //go back, since the list is a little shorter now.
                    currentCount--;//this keeps track of the healthbars, when new ones are created they're added to the end of the list and a reference is passed back.
                }
            }
            
            for(int i = 1; i < _anchors.Count; i++)
            {
                /*float distance = Vector2.Distance(_HealthBars[i].localPosition, Get2DPosition(_anchors[i])); ;
                if (distance > 15)//reduce jitter. if the distance has changed by 10. 
                {
                    _HealthBars[i].localPosition = Get2DPosition(_anchors[i]);
                }*/
               _HealthBars[i].localPosition = Get2DPosition(_anchors[i]);

            }
            
        }


    }
    #region DisplayBarsOnScreen
    [SerializeField]
    Vector2 RawPosition;

    [SerializeField]
    Vector2 camscreen;

    [SerializeField]
    float MAX_X;
    [SerializeField]
    float MAX_Y;
    [SerializeField]
    float MIN_X;
    [SerializeField]
    float MIN_Y;
    [SerializeField]
    float BAR_WIDTH;
    [SerializeField]
    float BAR_HEIGHT;

    [SerializeField]
    float FLOAT_ABOVE_OFFSET = 5;

    [SerializeField]
    Canvas _canvas;
    void SetSizes()
    {

        screen_width = _cam.pixelWidth;
        screen_height = _cam.pixelHeight;

        BAR_WIDTH = HealthBarPrefab.GetComponent<RectTransform>().sizeDelta.x;
        BAR_HEIGHT = HealthBarPrefab.GetComponent<RectTransform>().sizeDelta.y;

        _canvas = GetComponent<Canvas>();
        CANVAS_WIDTH = GetComponent<RectTransform>().sizeDelta.x;
        CANVAS_HEIGHT = GetComponent<RectTransform>().sizeDelta.y;

        /*
        //Clamp so that 80% of the viewport is viewable. 
        MAX_X = screen_width / 4f * 0.8f;
        MAX_Y = screen_height / 4f * 0.8f;
        MIN_X = (-1) * screen_width / 4f * 0.8f;
        MIN_Y = (-1) * screen_height / 4f * 0.8f;
        */

        MAX_X = CANVAS_WIDTH / 2f - BAR_WIDTH;
        MIN_X = (-1f) * MAX_X;
        MAX_Y = CANVAS_HEIGHT / 2f - BAR_HEIGHT/2f;
        MIN_Y = (-1f) * MAX_Y;
    }

    [SerializeField]
    float CANVAS_WIDTH;
    [SerializeField]
    float CANVAS_HEIGHT;
    Vector2 Get2DPosition(HealthAnchor _anchor)
    {

        float x = _cam.WorldToViewportPoint(_anchor.GetPosition()).x;
        float y = _cam.WorldToViewportPoint(_anchor.GetPosition()).y;

        RawPosition = new Vector2(x, y);

        float new_x = 0;
        float new_y = 0;

        new_x = RawPosition.x - 0.5f;
        new_x = new_x * CANVAS_WIDTH;

        new_y = RawPosition.y - 0.5f;
       new_y = new_y * CANVAS_HEIGHT;
        new_y = new_y + FLOAT_ABOVE_OFFSET;

        if(new_x > MAX_X)
        {
            new_x = MAX_X;
        }
        if(new_x < MIN_X)
        {
            new_x = MIN_X;
        }
        if(new_y > MAX_Y)
        {
            new_y = MAX_Y;
        }
        if(new_y < MIN_Y)
        {
            new_y = MIN_Y;
        }
        camscreen = new Vector2(new_x, new_y);
        return camscreen;
        //_target.GetComponent<RectTransform>().localPosition= camscreen;


    }
    #endregion
}
