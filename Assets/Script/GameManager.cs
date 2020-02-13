using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    float score, escore, wscore, dscore, snscore;
    public GameObject snw, ew, dw, ww;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score";
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = escore.ToString();
        if (E_Waste._locked && WetWaste._locked && dryWaste._locked && SanNHazWaste._locked)
        {
            score = escore + wscore + dscore + snscore;
            scoreText.text = "Score is : " + score.ToString();
        }

        
    }
    public void E_WasteScore(float score)
    {
        escore = score;
        Debug.Log("E-Waste : " + escore);
    }
    public void WWasteScore(float score)
    {
        wscore = score;
        Debug.Log("W-Waste : " + wscore);
    }
    public void DWasteScore(float score)
    {
        dscore = score;
        Debug.Log("D-Waste : " + dscore);
    }
    public void SNWasteScore(float score)
    {
        
        snscore = score;
        Debug.Log("SN-Waste : " + snscore +" "+ dscore + " " + escore + " " + wscore);
    }
}
