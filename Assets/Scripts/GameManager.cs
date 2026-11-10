
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameLost = false;

    private void Awake()
    {
        gameLost = false;
        RewardManager.ResetRewards();
        Time.timeScale = 1f;
    }

    public static void LoseGame()
    {
        if (gameLost || RewardManager.HasWon())
            return;

        gameLost = true;
        Time.timeScale = 0f;
    }

    private void OnGUI()
    {
        string message = "";

        if (gameLost)
            message = "YOU LOST!";
        else if (RewardManager.HasWon())
            message = "YOU WIN!";

        if (message == "")
            return;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 60;
        style.fontStyle = FontStyle.Bold;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = gameLost ? Color.red : Color.yellow;

        GUI.Label(
            new Rect(0, Screen.height / 2 - 60, Screen.width, 120),
            message,
            style
        );
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
