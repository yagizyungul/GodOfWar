using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float minY; // Kameran�n inebilece�i minimum Y pozisyonu

    void Start()
    {
        minY = transform.position.y; // Ba�lang��ta kameran�n Y pozisyonunu saklay�n
    }

    void LateUpdate()
    {
        float targetY = transform.position.y;

        // Sadece oyuncu yukar� ��kt���nda kameray� hareket ettir
        if (player.position.y + offset.y > transform.position.y)
        {
            targetY = player.position.y + offset.y;
        }

        // Oyuncunun pozisyonuna g�re kameran�n yeni pozisyonunu hesapla
        Vector3 desiredPosition = new Vector3(transform.position.x, Mathf.Max(targetY, minY), transform.position.z);

        // Kamera pozisyonunu yumu�ak bir �ekilde oyuncuya do�ru hareket ettir
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
