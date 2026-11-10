
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireInterval = 0.5f;
    public float disableDuration = 2f;
    public float cooldownDuration = 10f;

    private float fireTimer;
    private float disabledUntil;
    private float cooldownUntil;

    public bool IsDisabled => Time.time < disabledUntil;

    public float CooldownRemaining =>
        Mathf.Max(0f, cooldownUntil - Time.time);

    private void Update()
    {
        if (IsDisabled)
            return;

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;

            if (bulletPrefab != null)
            {
                Vector3 spawnPosition =
                    transform.position + Vector3.left * 0.6f;

                Instantiate(
                    bulletPrefab,
                    spawnPosition,
                    Quaternion.identity
                );
            }
        }
    }

    public void DisableTurret()
    {
        if (CooldownRemaining > 0f)
            return;

        disabledUntil = Time.time + disableDuration;
        cooldownUntil = Time.time + cooldownDuration;
        fireTimer = 0f;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 28;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;

        string message;

        if (IsDisabled)
            message = "TURRET DISABLED: " +
                      Mathf.CeilToInt(disabledUntil - Time.time) + "s";
        else if (CooldownRemaining > 0f)
            message = "COOLDOWN: " +
                      Mathf.CeilToInt(CooldownRemaining) + "s";
        else
            message = "PRESSURE PLATE READY";

        GUI.Label(new Rect(20, 20, 600, 50), message, style);
    }
}
