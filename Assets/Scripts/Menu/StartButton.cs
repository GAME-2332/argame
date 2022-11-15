using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{

    [SerializeField]
    string NextScene;

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
    }

    void StartGame()
    {
        Debug.Log("You start the game.");
    }
}
