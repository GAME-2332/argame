using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //code to start the level here, move to the level scene. 
    }
    public void SetLevelPrefab(GameObject pf)
    {
        LevelPrefab = pf;
    }

}
