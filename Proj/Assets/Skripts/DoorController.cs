using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool playerNearby = false;              // 플레이어가 문 근처에 있는지 여부
    private bool isOpen = false;                    // 문 열림 상태
    public float openAngle = 90f;                   // 열릴 각도
    public float smoothSpeed = 2f;                  // 열릴 속도
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                        transform.rotation.eulerAngles.y + openAngle,
                                        transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
        }

        // 부드럽게 문 열고 닫기
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                             isOpen ? openRotation : closedRotation,
                                             Time.deltaTime * smoothSpeed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
