
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public float deathHeight = -6f;

    private void Update()
    {
        if (transform.position.y < deathHeight)
        {
            GameManager.LoseGame();
        }
    }
}
