using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    private Color primaryColor;
    private Color secondaryColor;
    private Color tertiaryColor;
    private Color quarternaryColor;

    GameObject[] primaryTheme;
    GameObject[] secondaryTheme;
    GameObject[] tertiaryTheme;
    GameObject[] quarternaryTheme;

    private void Start()
    {
        ChangeTheme(PlayerPrefs.GetInt("choosenTheme"));
    }
    public void ChangeTheme(int themeSet)
    {
        PlayerPrefs.SetInt("choosenTheme", themeSet);

        switch (themeSet)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#68C9FF", out primaryColor);//Light Blue
                ColorUtility.TryParseHtmlString("#FFFFFF", out secondaryColor);//White
                ColorUtility.TryParseHtmlString("#231F20", out tertiaryColor);//Black
                ColorUtility.TryParseHtmlString("#231F20", out quarternaryColor);//Black
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#D1BCDB", out primaryColor); //Light Purple
                ColorUtility.TryParseHtmlString("#6D57A5", out secondaryColor); //Purple
                ColorUtility.TryParseHtmlString("#47366D", out tertiaryColor); //Darker Purple
                ColorUtility.TryParseHtmlString("#FFFFFF", out quarternaryColor); //White
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#0E1C3E", out primaryColor);//Navy Blue
                ColorUtility.TryParseHtmlString("#65C9D7", out secondaryColor);//Neon Blue
                ColorUtility.TryParseHtmlString("#FFFFFF", out tertiaryColor);//White
                ColorUtility.TryParseHtmlString("#231F20", out quarternaryColor);//Black
                break;
            default:
                ColorUtility.TryParseHtmlString("#68C9FF", out primaryColor);//Light Blue
                ColorUtility.TryParseHtmlString("#FFFFFF", out secondaryColor);//White
                ColorUtility.TryParseHtmlString("#231F20", out tertiaryColor);//Black
                ColorUtility.TryParseHtmlString("#231F20", out quarternaryColor);//Black
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

        foreach (GameObject obj in tertiaryTheme)
        {
            Image Image = obj.GetComponent<Image>();
            if (Image != null)
            {
                Image.color = tertiaryColor;
            }
        }

        foreach (GameObject obj in quarternaryTheme)
        {
            Image Image = obj.GetComponent<Image>();
            if (Image != null)
            {
                Image.color = quarternaryColor;
            }
        }

        Debug.Log("Change Theme Success!");
    }
}