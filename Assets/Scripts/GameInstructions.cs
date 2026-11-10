
using UnityEngine;

public class GameInstructions : MonoBehaviour
{
    public float instructionDuration = 5f;
    public float countdownDuration = 3f;
    public float goodLuckDuration = 1f;

    private float timer = 0f;
    private bool gameStarted = false;

    private void Start()
    {
        timer = 0f;
        gameStarted = false;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        timer += Time.unscaledDeltaTime;

        if (!gameStarted && timer >= instructionDuration)
        {
            gameStarted = true;
            Time.timeScale = 1f;
        }
    }

    private void OnGUI()
    {
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;

        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 32;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.yellow;

        GUIStyle textStyle = new GUIStyle(GUI.skin.label);
        textStyle.fontSize = 23;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;

        GUIStyle countdownStyle = new GUIStyle(GUI.skin.label);
        countdownStyle.fontSize = 70;
        countdownStyle.fontStyle = FontStyle.Bold;
        countdownStyle.alignment = TextAnchor.MiddleCenter;
        countdownStyle.normal.textColor = Color.yellow;

        GUIStyle goodLuckStyle = new GUIStyle(GUI.skin.label);
        goodLuckStyle.fontSize = 55;
        goodLuckStyle.fontStyle = FontStyle.Bold;
        goodLuckStyle.alignment = TextAnchor.MiddleCenter;
        goodLuckStyle.normal.textColor = Color.red;

        if (timer < instructionDuration)
        {
            GUI.Box(
                new Rect(centerX - 350, centerY - 190, 700, 380),
                ""
            );

            GUI.Label(
                new Rect(centerX - 340, centerY - 175, 680, 50),
                "FOREST ESCAPE - HOW TO PLAY",
                titleStyle
            );

            GUI.Label(
                new Rect(centerX - 340, centerY - 115, 680, 40),
                "MASK DUDE (PLAYER 1): UPPER PATH",
                textStyle
            );

            GUI.Label(
                new Rect(centerX - 340, centerY - 75, 680, 40),
                "MASK DUDE (PLAYER 2): UPPER PATH",
                textStyle
            );

            GUI.Label(
                new Rect(centerX - 340, centerY - 35, 680, 40),
                "PLAYER 1: A / D + SPACE",
                textStyle
            );

            GUI.Label(
                new Rect(centerX - 340, centerY + 5, 680, 40),
                "PLAYER 2: ARROW KEYS + L",
                textStyle
            );

            GUI.Label(
                new Rect(centerX - 340, centerY + 45, 680, 40),
                "COLLECT BOTH REWARDS TO WIN!",
                textStyle
            );

            float countdownStart =
                instructionDuration - countdownDuration;

            if (timer >= countdownStart)
            {
                int countdown = Mathf.CeilToInt(
                    instructionDuration - timer
                );

                GUI.Label(
                    new Rect(centerX - 100, centerY + 95, 200, 90),
                    countdown.ToString(),
                    countdownStyle
                );
            }
        }
        else if (timer < instructionDuration + goodLuckDuration)
        {
            GUI.Label(
                new Rect(centerX - 350, centerY - 60, 700, 120),
                "GOOD LUCK!",
                goodLuckStyle
            );
        }
    }
}
