using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float mouseSensitivity = 400f; //���콺����

    private float MouseY;
    private float MouseX;

    void Update()
    {
        //Rotate();
        //RayTest();
    }
    //private void Rotate()
    //{

    //    MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;

    //    MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

    //    MouseY = Mathf.Clamp(MouseY, -90f, 90f); //Clamp�� ���� �ּҰ� �ִ밪�� ���� �ʵ�����
    //    MouseX = Mathf.Clamp(MouseX, -90f, 90f); //Clamp�� ���� �ּҰ� �ִ밪�� ���� �ʵ�����

    //    transform.localRotation = Quaternion.Euler(MouseY, MouseX, 0f);// �� ���� �Ѳ����� ���
    //}

    //void RayTest() // ī�޶󿡼� ray�� ��������....
    //{
    //    Vector3 startPosition = transform.position -Vector3.up*20f;
    //    Debug.DrawRay(startPosition, transform.forward * 50f, Color.red);

    //    RaycastHit hit;

    //    if (Physics.Raycast(startPosition, transform.forward, out hit, 50))
    //    {
    //        int hitLayer = hit.collider.gameObject.layer;

    //        if (hitLayer == LayerMask.NameToLayer("Flowers"))
    //        {
    //            print("��");
    //            if (Input.GetKeyDown(KeyCode.G)) // �� ���
    //            {
    //                print("�� ����!");
    //                string hitname = hit.collider.gameObject.name;
    //                if (hitname.Substring(0, 6) == "flower")
    //                {
    //                    print(hit.collider.gameObject.name);
    //                }
    //                Destroy(hit.collider.gameObject);
    //            }
    //        }
    //    }
    //}
}