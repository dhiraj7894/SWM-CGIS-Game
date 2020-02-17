using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    float score, escore, wscore, dscore, snscore;
    List<int> IDs = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score";
    }

    // Update is called once per frame
    void Update() {
        
        scoreText.text = score.ToString();
        if (E_Waste.locked && WetWaste.locked && dryWaste.locked && SanNHazWaste.locked)
        {
            score = escore + wscore + dscore + snscore;
            scoreText.text = "Score is : " + score.ToString();
        }
    }
    public void E_WasteScore(float score, int iD)
    {
        IDs.Add(iD);
        escore = score;
    }
    public void WWasteScore(float score, int iD)
    {        
        wscore = score;
    }
    public void DWasteScore(float score, int iD)
    { 
        dscore = score;
    }
    public void SNWasteScore(float score, int iD)
    {
        snscore = score;
    }
}
