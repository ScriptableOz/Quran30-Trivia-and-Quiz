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

    private Color textColor1;
    private Color textColor2;


    GameObject[] primaryTheme;
    GameObject[] secondaryTheme;
    GameObject[] tertiaryTheme;
    GameObject[] quarternaryTheme;

    GameObject[] textColor1Theme;
    GameObject[] textColor2Theme;

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

                ColorUtility.TryParseHtmlString("#231F20", out textColor1);//Black
                ColorUtility.TryParseHtmlString("#FFFFFF", out textColor2);//White
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#D1BCDB", out primaryColor); //Light Purple
                ColorUtility.TryParseHtmlString("#6D57A5", out secondaryColor); //Purple
                ColorUtility.TryParseHtmlString("#47366D", out tertiaryColor); //Darker Purple
                ColorUtility.TryParseHtmlString("#FFFFFF", out quarternaryColor); //White

                ColorUtility.TryParseHtmlString("#231F20", out textColor1);//Black
                ColorUtility.TryParseHtmlString("#FFFFFF", out textColor2);//White
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#0E1C3E", out primaryColor);//Navy Blue
                ColorUtility.TryParseHtmlString("#65C9D7", out secondaryColor);//Neon Blue
                ColorUtility.TryParseHtmlString("#FFFFFF", out tertiaryColor);//White
                ColorUtility.TryParseHtmlString("#231F20", out quarternaryColor);//Black

                ColorUtility.TryParseHtmlString("#231F20", out textColor1);//Black
                ColorUtility.TryParseHtmlString("#FFFFFF", out textColor2);//White
                break;
            default:
                ColorUtility.TryParseHtmlString("#68C9FF", out primaryColor);//Light Blue
                ColorUtility.TryParseHtmlString("#FFFFFF", out secondaryColor);//White
                ColorUtility.TryParseHtmlString("#231F20", out tertiaryColor);//Black
                ColorUtility.TryParseHtmlString("#231F20", out quarternaryColor);//Black

                ColorUtility.TryParseHtmlString("#231F20", out textColor1);//Black
                ColorUtility.TryParseHtmlString("#FFFFFF", out textColor2);//White
                break;
        }

        primaryTheme = GameObject.FindGameObjectsWithTag("SetPrimaryColor");
        secondaryTheme = GameObject.FindGameObjectsWithTag("SetSecondaryColor");
        tertiaryTheme = GameObject.FindGameObjectsWithTag("SetTertiaryColor");
        quarternaryTheme = GameObject.FindGameObjectsWithTag("SetQuarternaryColor");

        textColor1Theme = GameObject.FindGameObjectsWithTag("SetTextColor1");
        textColor2Theme = GameObject.FindGameObjectsWithTag("SetTextColor2");

        foreach (GameObject obj in primaryTheme)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = primaryColor;
            }
        }

        foreach (GameObject obj in secondaryTheme)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = secondaryColor;
            }
        }

        foreach (GameObject obj in tertiaryTheme)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = tertiaryColor;
            }
        }

        foreach (GameObject obj in quarternaryTheme)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = quarternaryColor;
            }
        }

        foreach (GameObject obj in textColor1Theme)
        {
            Text textComponent = obj.GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.color = textColor1;
            }
        }

        foreach (GameObject obj in textColor2Theme)
        {
            Text textComponent = obj.GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.color = textColor2;
            }
        }


        Debug.Log("Change Theme Success!");
    }
}