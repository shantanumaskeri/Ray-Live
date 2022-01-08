using UnityEngine;

public class MouseConfiguration : MonoBehaviour
{

    #region Private variables

    private bool isCursorVisible = false;

    #endregion

    #region Monobehaviour Callbacks (start / update)

    private void Start()
    {
        Cursor.visible = isCursorVisible;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isCursorVisible = !isCursorVisible;
            Cursor.visible = isCursorVisible;
        }
    }

    #endregion

}
