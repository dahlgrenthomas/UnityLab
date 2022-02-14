using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour
{
    [SerializeField] private PongBall ball;
    [SerializeField] private PongGoal p1Goal;
    [SerializeField] private PongGoal p2Goal;
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;
    [SerializeField] private TMP_Text winText;
    private int p1Score = 0;
    private int p2Score = 0;
    
    private void Awake()
    {
        p1Goal.onScore += HandleP2Score;
        p2Goal.onScore += HandleP1Score;
        ball.Restart();
    }
    void HandleP2Score()
    {
        p2Score += 1;
        if(p2Score == 1)
        {
            winText.text = "Player 2 Wins!";
            StartCoroutine(EndGame());
        }
        else
        {
            player2Score.text = p2Score.ToString();
            ball.Restart();
        }

    }
    void HandleP1Score()
    {
        p1Score += 1;
        if (p1Score == 1)
        {
            winText.text = "Player 1 Wins!";
            StartCoroutine(EndGame());
        }
        else
        {
            player1Score.text = p1Score.ToString();
            ball.Restart();
        }

    }
    IEnumerator EndGame()
    {
        ball.StopBall();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}