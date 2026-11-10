
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        Vector3 center = (player1.position + player2.position) / 2f;
        center.z = -10f;

        transform.position = center;
    }
}
