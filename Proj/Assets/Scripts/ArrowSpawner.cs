using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;  // 화살 프리팹
    public Transform character;     // 캐릭터
    public Transform[] spawnPoints; // 🔹 특정 화살 스폰 위치 배열
    private float spawnInterval;    // 화살 생성 간격 (초)

    private float timer = 0f;

    void Start()
    {
        spawnInterval = Random.Range(1.5f, 3f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnArrow();
            timer = 0f;
            spawnInterval = Random.Range(1.5f, 3f); // 다음 발사 간격 랜덤 설정
        }
    }

    void SpawnArrow()
    {
        if (character == null || spawnPoints.Length == 0) return;

        // 🔹 통나무 아래 특정 위치에서 랜덤으로 선택
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 화살 생성 (스폰 포인트에서 발사)
        GameObject arrow = Instantiate(arrowPrefab, randomSpawnPoint.position, Quaternion.identity);
        Arrow arrowScript = arrow.GetComponent<Arrow>();

        if (arrowScript != null)
        {
            arrowScript.SetTarget(character.position); // 캐릭터 위치로 발사
        }

        // Debug: 생성 위치 확인
        Debug.Log($"화살 생성 위치: {randomSpawnPoint.position} → 목표: {character.position}");
    }
}
