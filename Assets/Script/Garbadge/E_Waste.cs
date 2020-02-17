using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class E_Waste : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private Vector2 _intialPlace;
    private CanvasGroup canvasGroup;
    private  float scoreData = 0f;
    private float chanceData = 3f;
    private GameManager gameManager;
    public static bool locked;
    public int iD;

    public void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        _intialPlace = rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBefinDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(eventData.pointerEnter.name == "EWST")
        {
            if(chanceData == 3)
            {
                scoreData = 4;
                Debug.Log(iD + " " + scoreData);
                Destroy(gameObject, 0.1f);
                gameManager.E_WasteScore(scoreData,iD);
                locked = true;
            }
            if (chanceData == 2)
            {
                Debug.Log(iD +" "+ scoreData);
                scoreData = 3;
                Destroy(gameObject, 0.1f);
                gameManager.E_WasteScore(scoreData, iD);
                locked = true;
            }
            if (chanceData == 1)
            {
                Debug.Log(iD +" "+ scoreData);
                scoreData = 2;
                Destroy(gameObject, 0.1f);
                gameManager.E_WasteScore(scoreData, iD);
                locked = true;
            }
            if (chanceData == 0)
            {
                Debug.Log(iD +" "+ scoreData);
                scoreData = 1;
                Destroy(gameObject, 0.1f);
                gameManager.E_WasteScore(scoreData, iD);
                locked = true;
            }
            if (chanceData < 0)
            {
                locked = false;
            }
        }
        else if(eventData.pointerEnter.name == "DWST")
        {
            chanceData--;
            rectTransform.anchoredPosition = new Vector2(_intialPlace.x, _intialPlace.y);
            Debug.Log("Error");
        }
        else if (eventData.pointerEnter.name == "WWST")
        {
            chanceData--;
            rectTransform.anchoredPosition = new Vector2(_intialPlace.x, _intialPlace.y);
            Debug.Log("Error");
        }
        else if (eventData.pointerEnter.name == "SnHWST")
        {
            chanceData--;
            rectTransform.anchoredPosition = new Vector2(_intialPlace.x, _intialPlace.y);
            Debug.Log("Error");
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(_intialPlace.x, _intialPlace.y);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        //Debug.Log("OnPointerDown");
    }
}
