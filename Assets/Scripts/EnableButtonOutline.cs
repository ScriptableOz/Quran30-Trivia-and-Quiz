using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutlineOnSelection : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Button targetButton;
    public Outline buttonOutline;

    private Button previouslySelectedButton; // Stores previously selected button

    void Start()
    {
        previouslySelectedButton = null; // Initialize to null
    }

    public void OnSelect(BaseEventData eventData)
    {
        // Disable outline on previously selected button (if any)
        var outline = previouslySelectedButton?.GetComponent<OutlineOnSelection>();
        if (outline != null)
        {
            outline.buttonOutline.enabled = false;
        }


        // Enable outline on current button
        buttonOutline.enabled = true;

        // Update previously selected button
        previouslySelectedButton = targetButton;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // No need to disable outline here, handled by OnSelect of new button
    }
}
