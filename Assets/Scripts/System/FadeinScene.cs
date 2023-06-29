using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class FadeinScene : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject changeCanvas;
    public float fadeDuration = 1.0f;

    private async void Start()
    {
        await FadeIn();
    }

    private async UniTask FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        canvasGroup.alpha = 0f;
        changeCanvas.gameObject.SetActive(false);
    }
}
