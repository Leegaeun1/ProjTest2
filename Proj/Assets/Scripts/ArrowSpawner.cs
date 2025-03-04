using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab; 
    public Transform character;
    public Transform[] spawnPoints; 
    private float spawnInterval;

    void Start()
    {
        spawnInterval = Random.Range(1.5f, 3f);
    }

    private void OnEnable()
    {
        spawnInterval = Random.Range(1.5f, 3f);
        InvokeRepeating(nameof(SpawnArrow), 0f, spawnInterval); 
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnArrow));
    }

    void SpawnArrow()
    {
        if (character == null || spawnPoints.Length == 0) return;

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject arrow = Instantiate(arrowPrefab, randomSpawnPoint.position, Quaternion.identity);
        Arrow arrowScript = arrow.GetComponent<Arrow>();

        if (arrowScript != null)
        {
            arrowScript.SetTarget(character.position); 
        }

    }
}
