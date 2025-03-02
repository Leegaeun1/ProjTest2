using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool playerNearby = false;              // �÷��̾ �� ��ó�� �ִ��� ����
    private bool isOpen = false;                    // �� ���� ����
    public float openAngle = 90f;                   // ���� ����
    public float smoothSpeed = 2f;                  // ���� �ӵ�
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

        // �ε巴�� �� ���� �ݱ�
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
