using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selector : MonoBehaviour
{
    [SerializeField]
    Level_Selector_Container container;
    [SerializeField]
    Button Left;
    [SerializeField]
    Button Right;

    [SerializeField]
    Button GoBackButton;

    [SerializeField]
    CanvasGroup cg;

    [SerializeField]
    int amountOfLevelsUnlocked;

    [SerializeField]
    int levelToLoad;

    [SerializeField]
    int totalLevels;

    List<int> Pages; //pages 1 loads 0 to 7, page 2 loads 8 to 14...
    int currentPage;

    bool CanvasIsOpen;

    int UNITS_PER_PAGE = 8;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
        totalLevels = 14;
        currentPage = 0;
        
        if(cg == null)
        {
            cg = GetComponent<CanvasGroup>();
        }
    }

    void SetUpPage(int pagenumber)
    {
        int units_to_display = UNITS_PER_PAGE;
        int firstlevel = pagenumber * UNITS_PER_PAGE;

        if(firstlevel > totalLevels)
        {
            currentPage--;
            return;
        }
       


        int lastlevel = (pagenumber + 1 ) * UNITS_PER_PAGE;

        if (lastlevel > totalLevels)
        {
            units_to_display = totalLevels - firstlevel;
        }
        List<string> level_number = new List<string>();
        List<bool> isUnlocked = new List<bool>();


        for (int i = 0; i < units_to_display; i++)
        {

            int current_level = firstlevel + i;
            level_number.Add((current_level).ToString());

           

            if((firstlevel+i) < amountOfLevelsUnlocked)
            {
                isUnlocked.Add(true);
            }
            else
            {
                isUnlocked.Add(false);
            }
        }
     

        container.CreateList(level_number, isUnlocked);
    }
    void GetReferences()
    {
        if(Left == null)
        {
            Left = transform.GetChild(2).GetComponent<Button>();
        }
        if(Right == null)
        {
            Right = transform.GetChild(3).GetComponent<Button>();
        }
        if(GoBackButton == null)
        {
            GoBackButton = GetComponent<Button>();
        }
        GoBackButton.onClick.AddListener(GoBack);
        Left.onClick.AddListener(PressLeft);
        Right.onClick.AddListener(PressRight);

        if(container == null)
        {
            container = GameObject.FindObjectOfType<Level_Selector_Container>();
        }
    }

    void PressLeft()
    {
        if(currentPage > 0)
        {
            currentPage--;
        }
      
        SetUpPage(currentPage);
        Debug.Log("turning left");
    }

    void PressRight()
    {
        currentPage++;
        SetUpPage(currentPage);
        Debug.Log("turning right");
    }

    public void GoBack()
    {
        CanvasIsOpen = false;
        Debug.Log("Going back to start.");
        if (cg == null)
        {
            cg = GetComponent<CanvasGroup>();
        }
        cg.interactable = false;
      
        cg.blocksRaycasts = false;
        StartCoroutine("FadeOut");
    }

    public void StartCanvas()
    {
        CanvasIsOpen = true;
        cg.interactable = true;
        SetUpPage(0);
      
        cg.blocksRaycasts = true;
        StartCoroutine("FadeIn");
    }

    public bool CheckOpenStatus()
    {
        return CanvasIsOpen;
    }

    IEnumerator FadeIn()
    {
        float percentage = 0;
        while(percentage < 1)
        {
            percentage += 0.2f;
            cg.alpha = percentage;
            yield return new WaitForSeconds(0.05f);

        }
        cg.alpha = 1;
        yield return new WaitForSeconds(0.05f);
    }
    IEnumerator FadeOut()
    {
        float percentage = 1;
        while(percentage > 0)
        {
            percentage -= 0.2f;
            cg.alpha = percentage;
            yield return new WaitForSeconds(0.05f);
        }
        cg.alpha = 0;
        yield return new WaitForSeconds(0.05f);
    }
}
