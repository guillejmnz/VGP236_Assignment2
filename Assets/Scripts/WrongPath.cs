
using UnityEngine;

public class WrongPath : MonoBehaviour
{
    public string forbiddenPlayer = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.name == forbiddenPlayer)
        {
            GameManager.LoseGame();
        }
    }
}
