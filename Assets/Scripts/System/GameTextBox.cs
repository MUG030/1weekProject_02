using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameTextBox : MonoBehaviour
{
    public TextMeshProUGUI textBox; // TextMeshProUGUIコンポーネントをアタッチしたテキストボックス
    public GameObject closeButton; // CloseButtonオブジェクト
    public GameObject returnButton; // ReturnButtonオブジェクト
    public GameObject explanationCanvas; // ExplanationCanvasのオブジェクト

    public TMP_Text textMeshPro;
    public List<string> textList;
    public float typingSpeed = 0.1f;

    private int currentIndex = 0;
    private bool isTyping = false;

    private void ShowNextText()
    {
        if (currentIndex < textList.Count)
        {
            isTyping = true;
            string textToType = textList[currentIndex];

            // エスケープ文字 \n を実際の改行に変換
            textToType = textToType.Replace("\\n", "\n");

            // DOTweenを使ってテキストをクリアしてからタイプライター風に表示
            textMeshPro.text = "";
            DOTween.To(() => textMeshPro.text, x => textMeshPro.text = x, textToType, textToType.Length * typingSpeed)
                .SetOptions(true)
                .SetEase(Ease.Linear)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    isTyping = false;

                    if (currentIndex == textList.Count)
                    {
                        Debug.Log("全ての文章が表示されました。");
                    }
                });
        }
        else
        {
            Debug.Log("次のシーンが呼ばれます");
            textBox.gameObject.SetActive(true);
        }
    }



    private void Start()
    {
        currentIndex = 0;
        ShowNextText();

        // CloseButtonにクリックイベントを追加
        closeButton.GetComponent<Button>().onClick.AddListener(HideText);
        // ReturnButtonにクリックイベントを追加
        returnButton.GetComponent<Button>().onClick.AddListener(ReturnText);
    }

    private void Update()
    {
        // クリックまたはタップで次のテキストを表示
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                currentIndex++;
                if (currentIndex >= textList.Count)
                {
                    HideText();
                }
                else
                {
                    ShowNextText();
                }
            }
        }
    }

    //private async Task ShowTextAsync()
    //{
    //    // テキストボックスを非表示にする
    //    textBox.gameObject.SetActive(false);

    //    // テキストボックスに現在のテキストを表示
    //    string currentText = dialogueList[currentIndex];
    //    await TypeTextAsync(currentText);

    //    // テキスト表示が完了したらテキストボックスを表示する
    //    textBox.gameObject.SetActive(true);
    //}

    //private IEnumerator TypeTextCoroutine(string text)
    //{
    //    textBox.text = ""; // テキストをクリア

    //    // 一文字ずつ表示するループ
    //    for (int i = 0; i < text.Length; i++)
    //    {
    //        textBox.text += text[i]; // 一文字追加
    //        yield return new WaitForSeconds(typingSpeed); // 次の文字まで待機
    //    }
    //}

    //private Task TypeTextAsync(string text)
    //{
    //    IEnumerator coroutine = TypeTextCoroutine(text);
    //    StartCoroutine(coroutine);
    //    return Task.CompletedTask;
    //}

    private void HideText()
    {
        // テキストボックスを非表示
        this.gameObject.SetActive(false);
        explanationCanvas.gameObject.SetActive(true);
    }

    private void ReturnText()
    {
        currentIndex--;
        if (currentIndex >= 0)
        {
            ShowNextText();
        }
    }
}

