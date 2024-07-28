using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private Collider2D blockCollider;
    public Transform player;

    void Start()
    {
        blockCollider = GetComponent<Collider2D>();
        blockCollider.enabled = false; // Baþlangýçta çarpýþma devre dýþý
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player.position.y > transform.position.y + 0.6f)
        {
            blockCollider.enabled = true; // Oyuncu bloðun yüksekliðini geçerse çarpýþmayý etkinleþtir
        }
        else
        {
            blockCollider.enabled = false; // Aksi takdirde çarpýþmayý devre dýþý býrak
        }
    }

}
