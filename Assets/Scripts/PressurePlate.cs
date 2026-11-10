
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Turret turret;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlle player =
            other.GetComponentInParent<PlayerControlle>();

        if (player == null)
            return;

        if (player.gameObject.name == "Player 2" && turret != null)
        {
            turret.DisableTurret();
        }
    }
}
