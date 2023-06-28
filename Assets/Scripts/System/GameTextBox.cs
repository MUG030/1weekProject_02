using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTextBox : MonoBehaviour
{
    public TextMeshProUGUI textBox; // TextMeshProUGUIコンポーネントをアタッチしたテキストボックス
    public List<string> dialogueList; // 表示するテキストのリスト
    private int currentIndex; // 現在表示しているテキストのインデックス
    public GameObject closeButton; // CloseButtonオブジェクト
    public GameObject returnButton; // ReturnButtonオブジェクト
    public GameObject explanationCanvas; // ExplanationCanvasのオブジェクト

    public float typingSpeed = 0.05f; // 一文字表示する速度

    private async void Start()
    {
        currentIndex = 0;
        await ShowTextAsync();
        // CloseButtonにクリックイベントを追加
        closeButton.GetComponent<Button>().onClick.AddListener(HideText);
        // ReturnButtonにクリックイベントを追加
        returnButton.GetComponent<Button>().onClick.AddListener(ReturnText);
    }

    private async void Update()
    {
        // クリックまたはタップで次のテキストを表示
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                currentIndex++;
                if (currentIndex >= dialogueList.Count)
                {
                    HideText();
                }
                else
                {
                    await ShowTextAsync();
                }
            }
        }
    }

    private async Task ShowTextAsync()
    {
        // テキストボックスを非表示にする
        textBox.gameObject.SetActive(false);

        // テキストボックスに現在のテキストを表示
        string currentText = dialogueList[currentIndex];
        await TypeTextAsync(currentText);

        // テキスト表示が完了したらテキストボックスを表示する
        textBox.gameObject.SetActive(true);
    }

    private IEnumerator TypeTextCoroutine(string text)
    {
        textBox.text = ""; // テキストをクリア

        // 一文字ずつ表示するループ
        for (int i = 0; i < text.Length; i++)
        {
            textBox.text += text[i]; // 一文字追加
            yield return new WaitForSeconds(typingSpeed); // 次の文字まで待機
        }
    }

    private Task TypeTextAsync(string text)
    {
        IEnumerator coroutine = TypeTextCoroutine(text);
        StartCoroutine(coroutine);
        return Task.CompletedTask;
    }

    private void HideText()
    {
        // テキストボックスを非表示
        this.gameObject.SetActive(false);
        explanationCanvas.gameObject.SetActive(true);
    }

    private async void ReturnText()
    {
        currentIndex--;
        if (currentIndex >= 0)
        {
            await ShowTextAsync();
        }
    }
}

