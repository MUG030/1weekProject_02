using UnityEngine;

public class RectangleDrawer : MonoBehaviour
{
    public float width = 1f; // 四角形の幅
    public float height = 1f; // 四角形の高さ

    private void Start()
    {
        DrawRectangle();
    }

    private void DrawRectangle()
    {
        Vector3 position = transform.position; // GameObjectの位置を取得
        Vector2 size = new Vector2(width, height); // 四角形のサイズを設定

        // 四角形の中心位置を計算
        Vector3 center = new Vector3(position.x, position.y - height / 2f, position.z);

        // 四角形を描画
        GameObject rectangle = new GameObject("Rectangle");
        rectangle.transform.position = center;
        rectangle.AddComponent<SpriteRenderer>().sprite = CreateRectangleSprite(size);
    }

    private Sprite CreateRectangleSprite(Vector2 size)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), Mathf.Max(size.x, size.y));

        // スプライトのサイズを設定
        sprite.bounds.SetMinMax(Vector3.zero, new Vector3(size.x, size.y, 0f));

        return sprite;
    }
}

