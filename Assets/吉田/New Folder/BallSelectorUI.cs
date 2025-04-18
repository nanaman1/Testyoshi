using UnityEngine;
using TMPro; // TextMeshPro を使うために追加

public class BallSelectorUI: MonoBehaviour
{
    [Header("球の日本語名")]
    public string[] ballNamesInJapanese;

    [Header("UI (TextMeshPro)")]
    public TextMeshProUGUI ballNameTMPText;

    private int selectedBallIndex = 0;

    void Start()
    {
        UpdateBallNameUI();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            selectedBallIndex = (selectedBallIndex + 1) % ballNamesInJapanese.Length;
            UpdateBallNameUI();
        }
        else if (scroll < 0f)
        {
            selectedBallIndex = (selectedBallIndex - 1 + ballNamesInJapanese.Length) % ballNamesInJapanese.Length;
            UpdateBallNameUI();
        }
    }

    void UpdateBallNameUI()
    {
        if (ballNameTMPText != null && selectedBallIndex < ballNamesInJapanese.Length)
        {
            ballNameTMPText.text = $"select：{ballNamesInJapanese[selectedBallIndex]}";
        }
    }

    public int GetSelectedBallIndex()
    {
        return selectedBallIndex;
    }
}
