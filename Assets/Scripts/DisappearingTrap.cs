
using UnityEngine;

public class DisappearingTrap : MonoBehaviour
{
    public float activeTime = 2f;
    public float inactiveTime = 2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D trapCollider;

    private float timer = 0f;
    private bool isActive = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();

        SetTrapState(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float duration = isActive ? activeTime : inactiveTime;

        if (timer >= duration)
        {
            timer = 0f;
            SetTrapState(!isActive);
        }
    }

    private void SetTrapState(bool active)
    {
        isActive = active;

        if (spriteRenderer != null)
            spriteRenderer.enabled = active;

        if (trapCollider != null)
            trapCollider.enabled = active;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckPlayer(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckPlayer(other);
    }

    private void CheckPlayer(Collider2D other)
    {
        if (!isActive)
            return;

        PlayerControlle player =
            other.GetComponentInParent<PlayerControlle>();

        if (player != null)
        {
            GameManager.LoseGame();
        }
    }
}
