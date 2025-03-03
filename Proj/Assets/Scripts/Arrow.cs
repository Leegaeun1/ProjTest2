using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f; // 화살 속도
    public float arcHeight = 200f; // 🔹 포물선의 높이 (통나무를 피하도록 설정)
    private Vector3 targetPosition; // 목표 위치 (고정)
    private Vector3 startPosition; // 시작 위치
    private float progress = 0f; // 진행도 (0 ~ 1)
    private bool isTargetSet = false;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        startPosition = transform.position;
        isTargetSet = true;

        // 🔹 처음 화살이 목표 방향을 바라보도록 설정
        Vector3 direction = (targetPosition - startPosition).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        if (!isTargetSet) return;

        progress += Time.deltaTime * speed * 0.1f; // 진행도 증가
        progress = Mathf.Clamp(progress, 0f, 1f); // 진행도를 0~1 범위로 제한

        // 🔹 포물선 공식 적용 (Bezier Curve 방식)
        Vector3 midPoint = (startPosition + targetPosition) / 2 + Vector3.up * arcHeight;
        Vector3 newPos = Vector3.Lerp(Vector3.Lerp(startPosition, midPoint, progress), Vector3.Lerp(midPoint, targetPosition, progress), progress);

        // 🔥 🔹 화살이 진행 방향을 향하도록 회전
        Vector3 moveDirection = (newPos - transform.position).normalized;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 10f);
        }

        transform.position = newPos;

        // 목표 지점 도달 시 제거
        if (progress >= 1f)
        {
            Debug.Log("화살이 목표 지점에 도달!");
            Destroy(gameObject);
        }
    }
}
