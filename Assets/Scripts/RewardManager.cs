
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public int rewardNumber = 1;

    private static bool reward1Collected;
    private static bool reward2Collected;

    public static void ResetRewards()
    {
        reward1Collected = false;
        reward2Collected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlle player = other.GetComponentInParent<PlayerControlle>();

        if (player == null)
            return;

        Debug.Log("Reward " + rewardNumber +
                  " touched by " + player.gameObject.name);

        bool isPlayer2 = player.gameObject.name == "Player 2";

        if (rewardNumber == 1 && !isPlayer2)
        {
            reward1Collected = true;
            Debug.Log("Reward 1 collected!");
            gameObject.SetActive(false);
        }
        else if (rewardNumber == 2 && isPlayer2)
        {
            reward2Collected = true;
            Debug.Log("Reward 2 collected!");
            gameObject.SetActive(false);
        }
    }

    public static bool HasWon()
    {
        return reward1Collected && reward2Collected;
    }
}
