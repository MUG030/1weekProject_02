using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab; // プレハブで生成するPlayerオブジェクト
    public Transform canvasTransform; // Playerオブジェクトを生成するCanvasのTransform

    private GameObject currentPlayer; // 現在のPlayerオブジェクト

    private void Start()
    {
        // inspectorから割り当てたオブジェクトをCanvasの子要素として生成する
        currentPlayer = Instantiate(playerPrefab, canvasTransform);
    }

    private void Update()
    {
        // スペースキーを押した場合、現在のPlayerオブジェクトを消して新しいオブジェクトを生成する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplacePlayer();
        }
    }

    private void ReplacePlayer()
    {
        // 現在のPlayerオブジェクトを削除する
        Destroy(currentPlayer);

        // プレハブから新しいPlayerオブジェクトを生成し、Canvasの子要素として設定する
        currentPlayer = Instantiate(playerPrefab, canvasTransform);
    }
}
