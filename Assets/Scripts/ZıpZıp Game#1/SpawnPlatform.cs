using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPlatform : MonoBehaviour
{   public GameObject blockPrefab; // Block prefab'ini buraya s�r�kleyin
    public Transform player; // Player objesini buraya s�r�kleyin
    public float spawnHeightOffset = 10f; // Yeni bloklar�n spawn olaca�� y�kseklik ofseti
    public float horizontalRange = 8f; // Bloklar�n yatayda spawn olaca�� aral�k
    public float verticalSpacingMin = 1f; // Bloklar aras�ndaki minimum dikey mesafe
    public float verticalSpacingMax = 3f; // Bloklar aras�ndaki maksimum dikey mesafe
    public float cleanupHeightOffset = 10f; // Gereksiz bloklar� silme y�ksekli�i ofseti

    private float lastSpawnY;
    private Camera mainCamera;

    void Start()
    {
        lastSpawnY = player.position.y;
        mainCamera = Camera.main;
        SpawnInitialBlocks();
    }

    void Update()
    {
        float cameraTopEdge = mainCamera.transform.position.y + mainCamera.orthographicSize;
        float cleanupThreshold = mainCamera.transform.position.y - mainCamera.orthographicSize - cleanupHeightOffset;

        if (player.position.y > lastSpawnY)
        {
            if (cameraTopEdge > lastSpawnY + spawnHeightOffset)
            {
                lastSpawnY += Random.Range(verticalSpacingMin, verticalSpacingMax);
                SpawnBlock();
            }
        }

        CleanupBlocks(cleanupThreshold);
    }

    void SpawnInitialBlocks()
    {
        // �lk bloklar� olu�tur
        for (float y = player.position.y; y < player.position.y + spawnHeightOffset; y += Random.Range(verticalSpacingMin, verticalSpacingMax))
        {
            float randomX = Random.Range(-horizontalRange, horizontalRange);
            Vector3 spawnPosition = new Vector3(randomX, y + 2, 0);
            Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnBlock()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        Vector3 spawnPosition = new Vector3(randomX, lastSpawnY + spawnHeightOffset, 0);
        Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }

    void CleanupBlocks(float cleanupThreshold)
    {
        // Bloklar� bul ve temizle
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            if (block.transform.position.y < cleanupThreshold)
            {
                Destroy(block);
            }
        }
    }
}
