using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    float currentPercent;
    [SerializeField]
    float nextPercent;
    [SerializeField]
    RectTransform health;
    [SerializeField]
    RectTransform shadow;
    // Start is called before the first frame update
    void Start()
    {
        if(health == null)
        {
            health = transform.GetChild(1).GetComponent<RectTransform>();
        }
        if(shadow == null)
        {
            shadow = transform.GetChild(0).GetComponent<RectTransform>();
        }
        currentPercent = 1f;
    }

    public void SetNextPercent(float newPercentage)
    {
        nextPercent = newPercentage;
        health.anchorMax = new Vector2(newPercentage, 1f);
        StartCoroutine("Decrement");
    }
    IEnumerator Decrement()
    {
        while (currentPercent - nextPercent > 0) 
        {
            currentPercent = currentPercent - 0.01f;
            shadow.anchorMax = new Vector2(currentPercent, 1f);
            if(currentPercent - nextPercent > 0.3)
            {
                //if there is a hit greater than 30% damage, decrease faster.
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
           
        }
        currentPercent = nextPercent;
        shadow.anchorMax = new Vector2(nextPercent, 1f);
        yield return new WaitForEndOfFrame();
    }

}
