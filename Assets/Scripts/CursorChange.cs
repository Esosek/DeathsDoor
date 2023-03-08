using UnityEngine;

public class CursorChange : MonoBehaviour
{

    public Texture2D defaultCursor;
    public Texture2D clickedCursor;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.SetCursor(clickedCursor, Vector2.zero, CursorMode.Auto);
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
