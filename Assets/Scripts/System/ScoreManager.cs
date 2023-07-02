using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using unityroom.Api;

public class ScoreManager : MonoBehaviour
{
    public Image fillImage; // fillAmountを持つImageコンポーネント
    public TextMeshProUGUI scoreText; // スコアを表示するTextMeshProコンポーネント

    private float currentScore = 0f; // 現在のスコア

    private void Start()
    {
        // スコアの初期値を設定
        currentScore = 0f;
    }

    private void Update()
    {
        // スペースキーを押した場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fillImageがnullでないことを確認する
            if (fillImage != null)
            {
                // fillAmountの値を取得
                float fillAmount = fillImage.fillAmount;

                // スコアを計算
                int score = CalculateScore(fillAmount);

                // スコアを表示
                UpdateScoreText(score);
            }
        }
    }

    private int CalculateScore(float fillAmount)
    {
        /*if (fillAmount < 0.4f || fillAmount >= 0.95f)
        {
            return 0;
        }*/
        if (fillAmount >= 0.4f && fillAmount < 0.5f)
        {
            return 50;
        }
        else if (fillAmount >= 0.5f && fillAmount < 0.6f)
        {
            return 100;
        }
        else if (fillAmount >= 0.6f && fillAmount < 0.7f)
        {
            return 200;
        }
        else if (fillAmount >= 0.7f && fillAmount < 0.79f)
        {
            return 300;
        }
        else if (fillAmount >= 0.79f && fillAmount < 0.81f)
        {
            return 500;
        }
        else if (fillAmount >= 0.81f && fillAmount < 0.9f)
        {
            return 300;
        }
        else if (fillAmount >= 0.9f && fillAmount < 0.95f)
        {
            return 50;
        }

        return 0;
    }

    private void UpdateScoreText(int score)
    {
        // スコアを更新して表示
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
        GameManager.instance.score = (int)currentScore;
        // ボードNo1にスコア123.45fを送信する。
        UnityroomApiClient.Instance.SendScore(1, currentScore, ScoreboardWriteMode.Always);

        // fillAmountが最大値に到達した場合、GameManagerにスコアを設定する
        if (fillImage.fillAmount >= 1f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
