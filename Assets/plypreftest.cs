using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plypreftest : MonoBehaviour
{
    public TMP_InputField text;

    public void save()
    {
        PlayerPrefs.SetString("Name",text.text);
    }

    public void load()
    {
        text.text = PlayerPrefs.GetString("Name");
    }
}
