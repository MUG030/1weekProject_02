using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float totalTime = 60f; // 制限時間の秒数
    public TMP_Text timerText; // タイマーを表示するTextMeshProテキスト

    private float countdownTime = 3f; // カウントダウンの秒数
    public TMP_Text countdownText; // カウントダウンを表示するTextMeshProテキスト

    private bool isGameStarted = false; // ゲームが開始されたかどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            UpdateTimer();
        }
    }

    // タイマーの更新
    void UpdateTimer()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // 制限時間終了時の処理
            // 例えばゲームオーバー処理などをここに記述する
        }
    }

    // タイマーのテキスト表示を更新
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // カウントダウンの開始
    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        isGameStarted = true;
    }
}

