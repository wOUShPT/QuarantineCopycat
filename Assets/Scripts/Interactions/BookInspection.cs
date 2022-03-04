using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookInspection : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private Text pageText;
    [SerializeField] private Button leftButton;
    private CanvasGroup leftButtonCanvasGroup;
    [SerializeField] private Button rightButton;
    private CanvasGroup rightButtonCanvasGroup;
    private List<string> textArray;
    private int pageIndex = 0;
    private bool isInspectionActivated = false;
    private bool wasTurnedPage = false;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        textArray = new List<string>();
        leftButtonCanvasGroup = leftButton.GetComponent<CanvasGroup>();
        rightButtonCanvasGroup = rightButton.GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (!isInspectionActivated)
        {
            return;
        }
        if (InputManager.Instance.InspectionInput.CancelInspection)
        {
            HideBook();
        }
        if(InputManager.Instance.InspectionInput.TurnPage > 0 && !wasTurnedPage) //positive
        {
            TurnPageRight();
        }
        if(InputManager.Instance.InspectionInput.TurnPage < 0 && !wasTurnedPage)
        {
            TurnPageLeft();
        }
        if(InputManager.Instance.InspectionInput.TurnPage == 0 && wasTurnedPage)
        {
            wasTurnedPage = false;
        }
    }
    public void SetTextArray(List<string> _textArray)
    {
        if( _textArray.Count > 0)
        {
            textArray = _textArray;
        }
        
    }
    public void DisplayBook()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        GetFirstPage();
        isInspectionActivated = true;
    }
    public void HideBook()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        isInspectionActivated = false;
    }
    private void GetFirstPage()
    {
        pageIndex = 0;
        DisplayButtons();
        pageText.text = textArray[pageIndex];

    }
    public void TurnPageLeft()
    {
        pageIndex--;
        if (pageIndex < 0)
        {
            // It's on the first page cannot go
            pageIndex = 0;
        }
        wasTurnedPage = true;
        DisplayButtons();
        pageText.text = textArray[pageIndex];
    }
    public void TurnPageRight()
    {
        //Turn next right page
        pageIndex++;
        if(pageIndex > textArray.Count - 1)
        {
            pageIndex = textArray.Count - 1;
        }
        wasTurnedPage = true;
        DisplayButtons();
        pageText.text = textArray[pageIndex];
        

    }
    private void DisplayButtons()
    {
        //Left Button
        leftButtonCanvasGroup.alpha = pageIndex <= 0 ? 0f : 1f; // don't show if it's on the beginning
        leftButtonCanvasGroup.blocksRaycasts = pageIndex <= 0 ? false : true;
        leftButtonCanvasGroup.interactable = pageIndex <= 0 ? false : true;
        //Right Button
        rightButtonCanvasGroup.alpha = pageIndex >= textArray.Count - 1 ? 0f : 1f; // don't show if it's on the beginning
        rightButtonCanvasGroup.blocksRaycasts = pageIndex >= textArray.Count - 1 ? false : true;
        rightButtonCanvasGroup.interactable = pageIndex >= textArray.Count - 1 ? false : true;
    }
}
