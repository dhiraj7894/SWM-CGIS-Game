using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SanNHazWaste : MonoBehaviour
{
    private GameManager gameManager;
    private float scoreData = 0f;
    private float chanceData = 3f;
    public static float score;



    public Transform _wWastePlace, _eWastePlace, _sHWastePlace, _dWastePlace;
    private Vector2 _intialPlace;
    private float _deltaX, _deltaY;
    public float b;
    public static bool _locked, _isSelected = false;

    public void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        b = 1f;
        Vector3 mousePosition = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);

        _intialPlace = transform.position;
    }

    void Update()
    {
        if (_isSelected == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
        else if (_isSelected == false)
        {
            if (Mathf.Abs(transform.position.x - _sHWastePlace.position.x) <= b && Mathf.Abs(transform.position.y - _sHWastePlace.position.y) <= b)
            {
                if (_sHWastePlace.name == "SNWaste")
                {
                    transform.position = new Vector2(_sHWastePlace.position.x, _sHWastePlace.position.y);
                    _locked = true;


                    score = scoreData;
                    if (chanceData == 3)
                    {
                        scoreData = 4;
                        Destroy(gameObject);
                        gameManager.SNWasteScore(scoreData);
                        _locked = true;
                        //Debug.LogWarning(scoreData);
                    }
                    if (chanceData == 2)
                    {
                        scoreData = 3;
                        Destroy(gameObject);
                        gameManager.SNWasteScore(scoreData);
                        _locked = true;
                        //Debug.LogWarning(scoreData);
                    }
                    if (chanceData == 1)
                    {
                        scoreData = 2;
                        Destroy(gameObject);
                        gameManager.SNWasteScore(scoreData);
                        _locked = true;
                        //Debug.LogWarning(scoreData);
                    }
                    if (chanceData == 0)
                    {
                        scoreData = 1;
                        Destroy(gameObject);
                        gameManager.SNWasteScore(scoreData);
                        _locked = true;
                        //Debug.LogWarning(scoreData);
                    }
                    if (chanceData < 0)
                    {
                        _locked = false;
                    }

                }
            }
            if (Mathf.Abs(transform.position.x - _wWastePlace.position.x) <= b && Mathf.Abs(transform.position.y - _wWastePlace.position.y) <= b)
            {
                //Debug.Log("WW");
                transform.position = new Vector2(_intialPlace.x, _intialPlace.y);
                if (_wWastePlace.name == "WWaste")
                {
                    chanceData--;
                    //Debug.Log("Error" + chanceData);
                }
            }
            if (Mathf.Abs(transform.position.x - _eWastePlace.position.x) <= b && Mathf.Abs(transform.position.y - _eWastePlace.position.y) <= b)
            {
                //Debug.Log("EW");
                transform.position = new Vector2(_intialPlace.x, _intialPlace.y);
                if (_eWastePlace.name == "EWaste")
                {
                    chanceData--;
                    //Debug.Log("Error" + chanceData);
                }
            }
            if (Mathf.Abs(transform.position.x - _dWastePlace.position.x) <= b && Mathf.Abs(transform.position.y - _dWastePlace.position.y) <= b)
            {
                //Debug.Log("DW");
                transform.position = new Vector2(_intialPlace.x, _intialPlace.y);
                if (_dWastePlace.name == "DWaste")
                {
                    chanceData--;
                    //Debug.Log("Error" + chanceData);
                }
            }

            else
            {
                transform.position = new Vector2(_intialPlace.x, _intialPlace.y);
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Vector3 mousePosition = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);

        _deltaX = mousePos.x - transform.localPosition.x;
        _deltaY = mousePos.y - transform.localPosition.y;
        _isSelected = true;
    }
    private void OnMouseUp()
    {
        _isSelected = false;
    }
}