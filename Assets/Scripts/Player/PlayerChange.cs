using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class PlayerChange : MonoBehaviour
{
    public Image fillImage; // 描画に使用するImageコンポーネント
    public float duration = 20f; // 描画にかける時間（秒）
    public float teaSpeed = 0.1f; // 上昇スピードの増加量

    private float targetFillAmount = 1f; // 目標のfillAmount（描画の完了度）
    private float currentSpeed = 1f; // 現在の上昇スピード

    private async UniTaskVoid Start()
    {
        fillImage.fillAmount = 0f;

        // 目標のfillAmountを設定
        targetFillAmount = 1f;

        // 3秒間待機
        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        // 描画を非同期に開始
        await StartDrawingAsync();
    }

    private void Update()
    {
        // 上矢印キーを押した場合、スピードを増加させる
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentSpeed += teaSpeed;
        }

        // 下矢印キーを押した場合、スピードを減少させる
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentSpeed -= teaSpeed;
            // スピードが0未満にならないようにクランプする
            currentSpeed = Mathf.Max(currentSpeed, 0f);
        }
    }

    private async UniTask StartDrawingAsync()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // fillAmountを徐々に増加させる
            float t = elapsedTime / duration;
            fillImage.fillAmount = Mathf.Lerp(0f, targetFillAmount, t);

            elapsedTime += Time.deltaTime * currentSpeed;
            await UniTask.Yield();

            // スペースキーを押した場合、描画をリセットして初めからやり直す
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 0.1秒待つ
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
                fillImage.fillAmount = 0f;
                elapsedTime = 0f;
            }
        }

        // 最終的なfillAmountを設定
        fillImage.fillAmount = targetFillAmount;
    }
}
