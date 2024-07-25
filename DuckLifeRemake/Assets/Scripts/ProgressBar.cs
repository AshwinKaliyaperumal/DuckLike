using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
CITATION: Some of the following code was adapted from this tutorial: https://www.youtube.com/watch?v=J1ng1zA3-Pk
*/

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public string statType;
    public Stats stats = DuckStatScript.stats;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = statType;

        minimum = 0;

        if (statType.Equals("swimming"))
        {
            maximum = (int)stats.requiredSwimmingXp;
        }
        else if (statType.Equals("running"))
        {
            maximum = (int)stats.requiredClimbingXp;
        }
        else if (statType.Equals("flying"))
        {
            maximum = (int)stats.requiredFlyingXp;
        }
        else if (statType.Equals("climbing"))
        {
            maximum = (int)stats.requiredClimbingXp;
        }
        else if (statType.Equals("stamina"))
        {
            //maximum = statManager.stats.requiredStamina;      there is no required/max stamina??
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        if (statType.Equals("swimming"))
        {
            current = (int)stats.currentSwimmingXp;
        }
        else if (statType.Equals("running"))
        {
            current = (int)stats.currentRunningXp;
        }
        else if (statType.Equals("flying"))
        {
            current = (int)stats.currentFlyingXp;
        }
        else if (statType.Equals("climbing"))
        {
            current = (int)stats.currentClimbingXp;
        }
        else if (statType.Equals("stamina"))
        {
            //current = statManager.stats.stamina;
        }

        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
    }
}
