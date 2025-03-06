using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float mouseSensitivity = 400f; //마우스감도

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

    //    MouseY = Mathf.Clamp(MouseY, -90f, 90f); //Clamp를 통해 최소값 최대값을 넘지 않도록함
    //    MouseX = Mathf.Clamp(MouseX, -90f, 90f); //Clamp를 통해 최소값 최대값을 넘지 않도록함

    //    transform.localRotation = Quaternion.Euler(MouseY, MouseX, 0f);// 각 축을 한꺼번에 계산
    //}

    //void RayTest() // 카메라에서 ray가 나오도록....
    //{
    //    Vector3 startPosition = transform.position -Vector3.up*20f;
    //    Debug.DrawRay(startPosition, transform.forward * 50f, Color.red);

    //    RaycastHit hit;

    //    if (Physics.Raycast(startPosition, transform.forward, out hit, 50))
    //    {
    //        int hitLayer = hit.collider.gameObject.layer;

    //        if (hitLayer == LayerMask.NameToLayer("Flowers"))
    //        {
    //            print("꽃");
    //            if (Input.GetKeyDown(KeyCode.G)) // 꽃 얻기
    //            {
    //                print("꽃 습득!");
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