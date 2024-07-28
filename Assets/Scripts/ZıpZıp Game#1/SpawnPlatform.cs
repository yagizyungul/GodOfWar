using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPlatform : MonoBehaviour
{   public GameObject blockPrefab; // Block prefab'ini buraya sürükleyin
    public Transform player; // Player objesini buraya sürükleyin
    public float spawnHeightOffset = 10f; // Yeni bloklarýn spawn olacaðý yükseklik ofseti
    public float horizontalRange = 8f; // Bloklarýn yatayda spawn olacaðý aralýk
    public float verticalSpacingMin = 1f; // Bloklar arasýndaki minimum dikey mesafe
    public float verticalSpacingMax = 3f; // Bloklar arasýndaki maksimum dikey mesafe
    public float cleanupHeightOffset = 10f; // Gereksiz bloklarý silme yüksekliði ofseti

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
        // Ýlk bloklarý oluþtur
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
        // Bloklarý bul ve temizle
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
