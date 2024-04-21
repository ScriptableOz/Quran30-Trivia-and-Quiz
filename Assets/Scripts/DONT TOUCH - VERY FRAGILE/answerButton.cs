using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class answerButton : MonoBehaviour
{
    private bool isCorrect;
    private TextMeshProUGUI answerText;
    private Button buttonComponent;

    private questionSetup questionSetup;
    private timeController timeController;

    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color correctColor = Color.green;
    [SerializeField] private Color wrongColor = Color.red;

    [SerializeField]
    private int score;

    private float rightDeedMulti = 0.5f;
    private float wrongDeedMulti = 0.05f;

    private float rightScoreMulti = 0.5f;
    private float wrongScoreMulti = -0.75f;

    private void Awake()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        answerText = GetComponentInChildren<TextMeshProUGUI>();

        // Get the Button component attached to this GameObject
        buttonComponent = GetComponent<Button>();

        // Find the questionSetup component in the scene
        questionSetup = FindObjectOfType<questionSetup>();
        if (questionSetup == null)
        {
            Debug.LogError("questionSetup not found in the scene!");
        }

        timeController = FindObjectOfType<timeController>();
        if (timeController == null)
        {
            Debug.LogError("timeController not found in the scene!");
        }

    }

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void onClick()
    {
        int i = questionSetup.counter;

        if (isCorrect)
        {
            // Calculate deeds and scores for the current question
            float rightDeeds = PlayerPrefs.GetFloat("Timer") * 0.5f;
            float rightScores = PlayerPrefs.GetFloat("Timer") * 0.5f;
            // Save deeds and scores for the current question
            PlayerPrefs.SetFloat("Deeds_" + i, Mathf.Round(rightDeeds * 100f) / 100f);
            PlayerPrefs.SetFloat("Scores_" + i, Mathf.Round(rightScores * 100f) / 100f);
            // Change the button's color to green
            StartCoroutine(turnGreen());
        }

        else
        {
            float wrongDeeds = PlayerPrefs.GetFloat("Timer") * 0.05f;
            float wrongScores = (11f - PlayerPrefs.GetFloat("Timer")) * -0.75f;
            // Save deeds and scores for the current question
            PlayerPrefs.SetFloat("Deeds_" + i, Mathf.Round(wrongDeeds * 100f) / 100f);
            PlayerPrefs.SetFloat("Scores_" + i, Mathf.Round(wrongScores * 100f) / 100f);

            // Change the button's color to red
            StartCoroutine(turnRed());
        }

        if (questionSetup.questions.Count > 0) // Changed the condition here
        {
            StartCoroutine(reload());
        }
        else
        {
            // If there is only one question left, change the scene
            StartCoroutine(resultPage(1));
        }
    }

    IEnumerator turnGreen()
    {
        buttonComponent.image.color = correctColor;
        yield return new WaitForSeconds(0.75f);
        buttonComponent.image.color = defaultColor;
        PlayerPrefs.SetInt("currentExp", PlayerPrefs.GetInt("currentExp") + 3);
    }

    IEnumerator turnRed()
    {
        buttonComponent.image.color = wrongColor;
        yield return new WaitForSeconds(0.75f);
        buttonComponent.image.color = defaultColor;
        PlayerPrefs.SetInt("currentExp", PlayerPrefs.GetInt("currentExp") + 1);
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(1);
        questionSetup.Start();
        timeController.Start();
    }

    IEnumerator resultPage(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Result");
    }

}
