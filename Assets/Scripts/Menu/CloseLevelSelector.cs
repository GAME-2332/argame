using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseLevelSelector : MonoBehaviour
{
    [SerializeField]
    Level_Selector selector;

    [SerializeField]
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        if(button == null)
        {
            button = GetComponent<Button>();
        }
        button.onClick.AddListener(ListenForClose);
        if(selector == null)
        {
            selector = GameObject.FindObjectOfType<Level_Selector>();
        }
    }

    void ListenForClose()
    {
        if (selector == null)
        {
            selector = GameObject.FindObjectOfType<Level_Selector>();
        }
        if(selector.CheckOpenStatus() == true)
        {
            selector.GoBack();
        }
    }
}
