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
        blockCollider.enabled = false; // Ba�lang��ta �arp��ma devre d���
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player.position.y > transform.position.y + 0.6f)
        {
            blockCollider.enabled = true; // Oyuncu blo�un y�ksekli�ini ge�erse �arp��may� etkinle�tir
        }
        else
        {
            blockCollider.enabled = false; // Aksi takdirde �arp��may� devre d��� b�rak
        }
    }

}
