using System.Collections;
using UnityEngine;

public class UpdraftZone : MonoBehaviour
{
    public float maxWindForce = 15f;  // 최대 바람 힘
    public float minWindForce = 5f;   // 최소 바람 힘
    public float windCycleTime = 3f;  // 바람 주기 (초)
    
    private float currentWindForce;
    private bool isPlayerInZone = false;
    private Rigidbody playerRb;

    void Start()
    {
        StartCoroutine(WindCycle());
    }

    IEnumerator WindCycle()
    {
        while (true)
        {
            // 바람이 강해지는 구간
            currentWindForce = maxWindForce;
            yield return new WaitForSeconds(windCycleTime);

            // 바람이 약해지는 구간
            currentWindForce = minWindForce;
            yield return new WaitForSeconds(windCycleTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            playerRb = null;
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInZone && playerRb != null)
        {
            playerRb.AddForce(Vector3.up * currentWindForce, ForceMode.Acceleration);
        }
    }
}
