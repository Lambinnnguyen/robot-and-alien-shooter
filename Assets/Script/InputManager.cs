using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private bool pausePressed = false;
    private bool reloadPressed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- CÁC HÀM LẤY DỮ LIỆU INPUT ---
    public Vector2 GetMovementInput()
    {
        Vector2 movement = Vector2.zero;
        if (isUpPressed) movement += Vector2.up;
        if (isDownPressed) movement += Vector2.down;
        if (isLeftPressed) movement += Vector2.left;
        if (isRightPressed) movement += Vector2.right;
        return movement;
    }

    // Hàm để GameManager hoặc script khác gọi để kiểm tra xem nút Pause có được bấm không
    public bool GetPauseInput()
    {
        bool result = pausePressed;
        pausePressed = false; // Reset lại false ngay sau khi đọc để tránh việc gọi liên tục
        return result;
    }

    // Hàm để GameManager hoặc script khác gọi để kiểm tra xem nút Reload có được bấm không
    public bool GetReloadInput()
    {
        bool result = reloadPressed;
        reloadPressed = false;
        return result;
    }

    // --- CÁC HÀM DI CHUYỂN (POINTER DOWN & UP) ---
    public void OnUpButtonDown() { isUpPressed = true; }
    public void OnUpButtonUp() { isUpPressed = false; }
    public void OnUpButtonExit() { isUpPressed = false; }

    public void OnDownButtonDown() { isDownPressed = true; }
    public void OnDownButtonUp() { isDownPressed = false; }
    public void OnDownButtonExit() { isDownPressed = false; }

    public void OnLeftButtonDown() { isLeftPressed = true; }
    public void OnLeftButtonUp() { isLeftPressed = false; }
    public void OnLeftButtonExit() { isLeftPressed = false; }

    public void OnRightButtonDown() { isRightPressed = true; }
    public void OnRightButtonUp() { isRightPressed = false; }
    public void OnRightButtonExit() { isRightPressed = false; }

    public void OnButtonUp()
    {
        isUpPressed = false;
        isDownPressed = false;
        isLeftPressed = false;
        isRightPressed = false;
    }

    // --- HÀM CHO NÚT PAUSE ---
    public void OnPauseButton()
    {
        pausePressed = true;
    }

    // --- HÀM CHO NÚT RELOAD ---
    public void OnReloadButton()
    {
        reloadPressed = true;
    }
}