using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // GameManagerからスコアを取得し、テキストに表示する
        if (GameManager.instance != null && GameManager.instance.score != null)
        {
            int score = GameManager.instance.score;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
