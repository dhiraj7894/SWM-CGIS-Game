using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WetWaste : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private Vector2 _intialPlace;
    private CanvasGroup canvasGroup;
    private GameManager gameManager;
    private static float scoreData = 0f;
    private float chanceData = 3f;
    public static float score;
    public static bool locked;
    public string name, cat;

    public void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        _intialPlace = rectTransform.anchoredPosition;
    }

    //when we start dragging a garbadge just set alpha value 0.6 so it will look like little bit transperent.
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBefinDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    //when we drag a object just keep object on the position of mouse pointer.
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //on the stop of drag just check 
    //1. set object alpha 1 so it will not transperent.
    //2. check where the my garbadge is on which dustbin.
    //3. if dustbin is any of other than Wet-Waste then place the garbadge position initial.
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // if garbadge is on Wet-Waste dustbin
        // set the score adding the chance of player
        // and send the Score, Name of garbadge and Category of garbadge at game Manager
        if (eventData.pointerEnter.name == "WWST")
        {
            scoreData = chanceData + 1;
            gameManager.E_WasteScore(scoreData, name, cat);
            locked = true;
            Destroy(gameObject, 0.1f);
        }

        // if garbadge is placed on other dustbin just decrease the chance and place the garbadge at initial position.
        else if (eventData.pointerEnter.name == "EWST" || eventData.pointerEnter.name == "DWST" || eventData.pointerEnter.name == "SnHWST")
        {
            chanceData--;
            rectTransform.anchoredPosition = new Vector2(_intialPlace.x, _intialPlace.y);
            Debug.Log("Error");
        }

        // else place the position of garbadge on initial.
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
