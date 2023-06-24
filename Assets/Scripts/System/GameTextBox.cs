using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTextBox : MonoBehaviour
{
    public TextMeshProUGUI textBox; // TextMeshProUGUIコンポーネントをアタッチしたテキストボックス
    public List<string> dialogueList; // 表示するテキストのリスト
    private int currentIndex; // 現在表示しているテキストのインデックス
    public GameObject closeButton; // CloseButtonオブジェクト

    private void Start()
    {
        currentIndex = 0;
        ShowText();
        // CloseButtonにクリックイベントを追加
        closeButton.GetComponent<Button>().onClick.AddListener(HideText);
    }

    private void Update()
    {
        // クリックまたはタップで次のテキストを表示
        if (Input.GetMouseButtonDown(0))
        {
            currentIndex++;
            if (currentIndex >= dialogueList.Count)
            {
                // テキストがすべて表示された場合、何かしらの処理を行う（ゲームの進行、次のイベントなど）
                // ここではテキストの表示を終了する例とします
                HideText();
            }
            else
            {
                ShowText();
            }
        }
    }

    private void ShowText()
    {
        // テキストボックスに現在のテキストを表示
        textBox.text = dialogueList[currentIndex];
        // テキストボックスを表示
        textBox.gameObject.SetActive(true);
    }

    private void HideText()
    {
        // テキストボックスを非表示
        textBox.gameObject.SetActive(false);
    }
}
