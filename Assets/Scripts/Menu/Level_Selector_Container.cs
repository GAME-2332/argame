using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XR;

public class Level_Selector_Container : MonoBehaviour
{
    List<GameObject> AllButtons;
    [SerializeField]
    GameObject AvailableLevelPrefab;
    [SerializeField]
    GameObject UnAvailableLevelPrefab;

    [SerializeField]
    SceneReference playable_level;
    // Start is called before the first frame update
    void Start()
    {
        if(AvailableLevelPrefab == null)
        {
            AvailableLevelPrefab = Resources.Load<GameObject>("Prefabs/Main Menu/Level_Unit_Available");
        }
        if(UnAvailableLevelPrefab == null)
        {
            UnAvailableLevelPrefab = Resources.Load<GameObject>("Prefabs/Main Menu/Level_Unit_Unavailable");
        }
    }

    void GetReferences()
    {
        if (AvailableLevelPrefab == null)
        {
            AvailableLevelPrefab = Resources.Load<GameObject>("Prefabs/Main Menu/Level_Unit_Available");
        }
        if (UnAvailableLevelPrefab == null)
        {
            UnAvailableLevelPrefab = Resources.Load<GameObject>("Prefabs/Main Menu/Level_Unit_Unavailable");
        }
    }

    public void CreateList(List<string> Level_Numbers, List<bool> UnlockedStatus)
    {
        DestroyMyKids();
        GetReferences();
        GameObject current;
        Debug.Log("creating a list with x objects" + Level_Numbers.Count);
        for(int i = 0; i < Level_Numbers.Count; i++)
        {
            if (UnlockedStatus[i] == true)
            {
               current = Instantiate(AvailableLevelPrefab,transform);
            }
            else
            {
                current = Instantiate(UnAvailableLevelPrefab, transform);
            }
            current.GetComponent<lvl_button>().SetName(Level_Numbers[i]);

            current.GetComponent<lvl_button>().SetUnlocked(UnlockedStatus[i]);

            current.GetComponent<lvl_button>().SetLevelSelectorRef(this);


            //current.GetComponent<lvl_button>().SetLevelPrefab();
            // Load the referenced scene
        }

    }
    public void StartLevel(int level_choice)
    {
        Debug.Log("Starting level" + level_choice);
        GameManager.QueueLoadLevel(level_choice);
        SceneManager.LoadScene(playable_level.ScenePath);

    }
    void DestroyMyKids()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
