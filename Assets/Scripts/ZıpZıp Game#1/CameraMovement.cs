using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float minY; // Kameranýn inebileceði minimum Y pozisyonu

    void Start()
    {
        minY = transform.position.y; // Baþlangýçta kameranýn Y pozisyonunu saklayýn
    }

    void LateUpdate()
    {
        float targetY = transform.position.y;

        // Sadece oyuncu yukarý çýktýðýnda kamerayý hareket ettir
        if (player.position.y + offset.y > transform.position.y)
        {
            targetY = player.position.y + offset.y;
        }

        // Oyuncunun pozisyonuna göre kameranýn yeni pozisyonunu hesapla
        Vector3 desiredPosition = new Vector3(transform.position.x, Mathf.Max(targetY, minY), transform.position.z);

        // Kamera pozisyonunu yumuþak bir þekilde oyuncuya doðru hareket ettir
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
