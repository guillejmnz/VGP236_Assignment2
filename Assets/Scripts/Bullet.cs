
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlle player =
            other.GetComponentInParent<PlayerControlle>();

        if (player != null)
        {
            GameManager.LoseGame();
            Destroy(gameObject);
        }
        else if (other.gameObject.layer ==
                 LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
