using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{

    [SerializeField]
    Level_Selector selector;

    [SerializeField]
    Button _button;
    // Start is called before the first frame update
    void Start()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }
        _button.onClick.AddListener(StartGame);
        if (selector == null)
        {
            selector = GameObject.FindObjectOfType<Level_Selector>();
        }
    }

    void StartGame()
    {
        Debug.Log("You start the game.");
        if (selector == null)
        {
            selector = GameObject.FindObjectOfType<Level_Selector>();
        }
        selector.StartCanvas();
    }
}
