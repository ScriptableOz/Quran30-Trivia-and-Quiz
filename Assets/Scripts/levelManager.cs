using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public Image expFillBar;

    [SerializeField]
    private TextMeshProUGUI playerLevel;
    [SerializeField]
    private TextMeshProUGUI expPoints;

    private void Start()
    {
        //StartCoroutine(ExpIncreaseCoroutine()); UNCOMMENT TO TEST LEVEL
    }

    private IEnumerator ExpIncreaseCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            PlayerPrefs.SetInt("currentExp", PlayerPrefs.GetInt("currentExp") + 1);
        }
    }

    private void UpdateUI()
    {
        playerLevel.text = PlayerPrefs.GetInt("playerLevel").ToString();
        expPoints.text = PlayerPrefs.GetInt("currentExp") + "/" + PlayerPrefs.GetInt("currentMaxExp");

        float fillAmount = (float)PlayerPrefs.GetInt("currentExp") / PlayerPrefs.GetInt("currentMaxExp");
        expFillBar.fillAmount = fillAmount;
    }

    private void Update()
    {
        UpdateUI();
        IncreaseMaxExp();
    }

    public void IncreaseMaxExp()
    {
        if (PlayerPrefs.GetInt("currentExp") >= PlayerPrefs.GetInt("currentMaxExp"))
        {
            PlayerPrefs.SetInt("currentMaxExp", PlayerPrefs.GetInt("currentMaxExp") + 50);
            PlayerPrefs.SetInt("currentExp", 0);
            PlayerPrefs.SetInt("playerLevel", PlayerPrefs.GetInt("playerLevel") + 1);
        }
    }
}

