using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    static private Scorekeeper instance;
    static public Scorekeeper Instance
    {
        get { return instance; }
    }

    public int pointsPerGoal = 1;
    private int[] score = new int[2];
    public Text[] scoreText;
    public Text WinnerText;
    static public int test = 0;


    public void OnScoreGoal(int player)
    {
        score[player] += pointsPerGoal;
        scoreText[player].text = score[player].ToString();

        if(score[player] == 10)
        {
            GameOver(player);
        }
    }

    public void GameOver(int player)
    {
        WinnerText.text = "PLAYER " + player + " Wins!";
        Time.timeScale = 0;
    }

    void Start()
    {
        if (instance == null)
        {
            // save this instance
            instance = this;
        }
        else
        {
            // more than one instance exists
            Debug.LogError(
            "More than one Scorekeeper exists in the scene.");
        }
        // reset the scores to zero
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0;
            scoreText[i].text = "0";
        }

    }
}
