using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    private Color primaryColor;
    private Color secondaryColor;

    GameObject[] primaryTheme;
    GameObject[] secondaryTheme;

    public void ChangeTheme(int themeSet)
    {
        print("tapped");

        switch (themeSet)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#68C9FF", out primaryColor);
                ColorUtility.TryParseHtmlString("#FFFFFF", out secondaryColor);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#b49fcc", out primaryColor);
                ColorUtility.TryParseHtmlString("#6d466b", out secondaryColor);
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#22162B", out primaryColor);
                ColorUtility.TryParseHtmlString("#57C4E5", out secondaryColor);
                break;
            default:
                ColorUtility.TryParseHtmlString("#68C9FF", out primaryColor);
                ColorUtility.TryParseHtmlString("#FFFFFF", out secondaryColor);
                break;
        }

        primaryTheme = GameObject.FindGameObjectsWithTag("SetPrimaryColor");
        secondaryTheme = GameObject.FindGameObjectsWithTag("SetSecondaryColor");

        foreach (GameObject obj in primaryTheme)
        {
            Image Image = obj.GetComponent<Image>();
            if (Image != null)
            {
                Image.color = primaryColor;
            }
        }

        foreach (GameObject obj in secondaryTheme)
        {
            Image Image = obj.GetComponent<Image>();
            if (Image != null)
            {
                Image.color = secondaryColor;
            }
        }

        Debug.Log("Change Theme Success!");
    }
}