using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaLength : MonoBehaviour
{
    public GameObject rectangle; // 四角形のオブジェクト
    public float resizeAmount = 0.1f; // 変更する幅の増減量
    public float maxScale = 2.0f; // 幅の最大値

    private Vector3 initialScale; // 初期スケール

    private void Start()
    {
        // 初期スケールを保存
        initialScale = rectangle.transform.localScale;
    }

    private void Update()
    {
        // 上矢印キーを押した場合、幅を増やす
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResizeRectangle(resizeAmount);
        }

        // 下矢印キーを押した場合、幅を減らす
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ResizeRectangle(-resizeAmount);
        }
    }

    private void ResizeRectangle(float amount)
    {
        // 幅を変更
        Vector3 newScale = rectangle.transform.localScale;
        newScale.x += amount;
        newScale.x = Mathf.Clamp(newScale.x, initialScale.x, maxScale); // 幅の最大値を制限
        rectangle.transform.localScale = newScale;
    }
}
