using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBridgeTrigger : MonoBehaviour
{
    public ArrowSpawner[] arrowSpawners;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateSpawners());
        }
    }

    IEnumerator ActivateSpawners()
    {
        ArrowSpawner[] allSpawners = FindObjectsOfType<ArrowSpawner>();
        foreach (ArrowSpawner spawner in allSpawners)
        {
            spawner.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);

        foreach (ArrowSpawner spawner in arrowSpawners)
        {
            spawner.gameObject.SetActive(true);
        }
    }
}
