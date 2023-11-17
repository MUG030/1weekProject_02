using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class FadeoutScene : MonoBehaviour
{
    public Button button;
    public CanvasGroup canvasGroup;
    public GameObject changeCanvas;
    public float fadeDuration = 1.0f;
    public string sceneName;

    private async void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private async void OnButtonClick()
    {
        changeCanvas.gameObject.SetActive(true);
        await FadeOut();
        await ChangeSceneAsync(); // メソッド名を変更し、非同期の操作を待機するよう修正
    }

    private async UniTask FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        canvasGroup.alpha = 1f;
    }

    private async UniTask ChangeSceneAsync() // メソッド名を変更し、非同期メソッドに修正
    {
        Debug.Log("シーンが呼ばれた");
        SceneManager.LoadScene(sceneName);
    }

}
