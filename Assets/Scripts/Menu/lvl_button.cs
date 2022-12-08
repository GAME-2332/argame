using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XR;

public class lvl_button : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text level_number;
    [SerializeField]
    bool unlocked;
    [SerializeField]
    Button button;
    [SerializeField]
    GameObject LevelPrefab;
    [SerializeField]
    SceneReference level_scene;

    [SerializeField]
    Level_Selector_Container container_ref;
    private void Start()
    {
        GetReferences();
        button.onClick.AddListener(OnClickStartLevel);
    }

    void GetReferences()
    {

        if (level_number == null)
        {
            level_number = GetComponentInChildren<TMPro.TMP_Text>();
        }
        if (button == null)
        {
            button = GetComponent<Button>();
        }
        
    
    }
    public void SetName(string s)
    {

        GetReferences();
        level_number.text = s;  
    }

    public void SetUnlocked(bool b)
    {

        GetReferences();
        if (b == true)
        {
            unlocked = b;
            button.interactable = true;

        }
        else
        {
            unlocked = false;
            button.interactable = false;
        }
    }

    void OnClickStartLevel()
    {
        Debug.Log("Loading level..." + level_number.text);
        int current_level = Int32.Parse(level_number.text);
        

        if(container_ref == null)
        {
            container_ref = GameObject.FindObjectOfType<Level_Selector_Container>();
        }
        container_ref.StartLevel(current_level);
        // Load the referenced scene
        //code to start the level here, move to the level scene. 
    }
    public void SetLevelSelectorRef(Level_Selector_Container myref)
    {
        container_ref = myref;
    }

}
