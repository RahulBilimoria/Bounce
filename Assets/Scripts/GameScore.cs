using System.Collections;
using System.Collections.Generic;
using UnityEngine;   
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int score;
    private int combo;
    public Text comboText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        combo = 1;
    }

    // Update is called once per frame

    public void UpdateScore(int p){
        AddScore(p * GameManager.manager.pointsMultiplier * combo);
        UpdateScoreText();
    }
    private void AddScore(int p){
        score += p;
    }

    private void UpdateScoreText(){
        GetComponent<Text>().text = "Points: " + score;
    }

    private void UpdateComboText(){
        comboText.text = "x" + combo;
    }

    public void AddTapCombo(){
        UpdateComboText();
        if (combo < GameManager.manager.comboMultiplier) combo++;
    }

    public void ResetTapCombo(){
        combo = 1;
    }
}
