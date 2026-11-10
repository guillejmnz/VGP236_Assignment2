
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlle player = other.GetComponentInParent<PlayerControlle>();

        if (player != null)
        {
            GameManager.LoseGame();
        }
    }
}
