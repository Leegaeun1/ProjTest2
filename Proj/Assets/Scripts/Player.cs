using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float Speed = 20.0f;     // �����̴� �ӵ�
    float ry;
    float h, v;
    public float rotateSpeed=100.0f;
    private float MouseY;
    private float MouseX;
    public float mouseSensitivity = 400f; //���콺����

    //bool isWalking = false;
    bool isJump = false;
    bool isfalling = true;
    bool isClick = false; // �κ��丮 Ŭ���ߴ���

    bool isGround = true;
    //bool isRun = false;

    public float jumpForce = 10f;
    public GameObject inven;
    private Rigidbody rb;
    Animator anim;

    void Start()
    {
        ry=transform.eulerAngles.y;
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        ColliderObject();
        GroundCheck();
        Move();
        Jump();
        Inven();


    }
    void ColliderObject()
    {
        Vector3 startPosition = transform.position + Vector3.up * 15f;
        Debug.DrawRay(startPosition, transform.forward * 10f, Color.red);

        RaycastHit[] hits = Physics.RaycastAll(startPosition, transform.forward, 10);

        foreach (RaycastHit hit in hits)
        { 
            int hitLayer = hit.collider.gameObject.layer;

            if (hitLayer == LayerMask.NameToLayer("Logs"))
            {
                if (Input.GetKeyDown(KeyCode.G)) // ���� ���
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hitLayer == LayerMask.NameToLayer("Default"))
            {
                v = 0;
            }
        }
    }


    void GroundCheck()
    {
        Vector3 startPosition = transform.position + Vector3.up;
        Debug.DrawRay(startPosition, -transform.up , Color.red);
        RaycastHit rayHit;
        //, LayerMask.GetMask("Ground")
        if (Physics.Raycast(startPosition, -transform.up*5f, out rayHit, 5))
        {
            isGround = true;
            isfalling = false;
        }
        else
        {
            isGround = false;
            isfalling = true;

        }

        anim.SetBool("isFalling", isfalling);
        anim.SetBool("isGround", isGround);
    }



    private void Jump() // �����ϱ�
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            print("�����̽� ����");

            isJump = true;
            isfalling = false;

            anim.SetBool("isFalling", isfalling);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //?????
        }
        anim.SetBool("isJump", isJump);
    }


    void JumpBool() // �ִϸ��̼� �̺�Ʈ
    {
        print(1);
        isJump = false;
    }


    void Move()
    {
        if (Input.GetButton("Sprint")) // Run
        {
            Speed = 50.0f;
        }
        else
        {
            Speed = 20.0f;
        }
        Vector3 moveDirection = (transform.forward * v + transform.right * h).normalized;
        transform.position += moveDirection * Speed * Time.deltaTime;


        MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        MouseY = Mathf.Clamp(MouseY, -15f, 15f); 
        transform.localRotation = Quaternion.Euler(MouseY, MouseX, 0f);

        if (v == 0 && h==0)
        {
            Speed = 0;
        }

        anim.SetFloat("Speed", Speed);
    }

    void Inven()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            if (!isClick) // �κ��丮 �ݱ�
            {
                inven.SetActive(false);
                isClick = true;
            }
            else // �κ��丮 ����
            {
                inven.SetActive(true);
                isClick = false;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            v = 0;
            print("�浹22");
        }
    }
}
