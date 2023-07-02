using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button; // ボタンコンポーネント
    public AudioClip soundClip; // 再生する音声の AudioClip
    private AudioSource audioSource; // 音声再生用の AudioSource

    private void Start()
    {
        // ボタンのクリックイベントにメソッドを追加
        button.onClick.AddListener(PlaySound);

        // AudioSource コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource コンポーネントがアタッチされていない場合は追加する
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void PlaySound()
    {
        // 音声を再生
        audioSource.PlayOneShot(soundClip);
    }
}

