using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float Speed = 20.0f;     // 움직이는 속도
    float ry;
    float h, v;
    public float rotateSpeed=100.0f;
    private float MouseY;
    private float MouseX;
    public float mouseSensitivity = 400f; //마우스감도

    //bool isWalking = false;
    bool isJump = false;
    bool isfalling = true;
    bool isClick = false; // 인벤토리 클릭했는지

    bool isGround = true;
    bool sitDown = false;

    public float jumpForce = 10f;
    public GameObject inven;
    private Rigidbody rb;
    Animator anim;

    public Inventory inven11;

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
        SitDown();

    }
    void ColliderObject()
    {
        Vector3 startPosition = transform.position + Vector3.up * 10f;
        Debug.DrawRay(startPosition, transform.forward * 12f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(startPosition, transform.forward, out hit, 12))
        {
            int hitLayer = hit.collider.gameObject.layer;

            LayerCheck("log", hit, hitLayer);
            LayerCheck("flower", hit, hitLayer);

            if (hitLayer == LayerMask.NameToLayer("Default"))
            {
                print("충돌!");
                v = 0;
            }

            if (hitLayer == LayerMask.NameToLayer("Door"))
            {
                print("충돌33");
                
                v = 0;
            }
        }
        
    }

    void LayerCheck(string name, RaycastHit hit, int hitLayer)
    {
        if (hitLayer == LayerMask.NameToLayer(name))
        {
            if (Input.GetKeyDown(KeyCode.G)) // 물체 얻기
            {
                print("습득!");
                string hitname = hit.collider.gameObject.name;
                if (hitname.Substring(0, name.Length) == name)
                {
                    print(hit.collider.gameObject.name);
                    inven11.Check(name);
                }
                Destroy(hit.collider.gameObject);
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



    private void Jump() // 수정하기
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {

            isJump = true;
            isfalling = false;

            anim.SetBool("isFalling", isfalling);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //?????
        }
        anim.SetBool("isJump", isJump);
    }


    void JumpBool() // 애니메이션 이벤트
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
            
            if (!isClick) // 인벤토리 닫기
            {
                inven.SetActive(false);
                isClick = true;
            }
            else // 인벤토리 열기
            {
                inven.SetActive(true);
                isClick = false;
            }
            
        }
    }


    void SitDown()
    {
        BoxCollider character = GetComponent<BoxCollider>();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            if (!sitDown)
            {
                sitDown = true; // 왜 올라가지,,,,............
                character.center = new Vector3(character.center.x, +1.4f, character.center.z);
                
            }
            else
            {
                sitDown = false;
                character.center = new Vector3(character.center.x, 0.8808745f, character.center.z);
            }
            anim.SetBool("sitDown", sitDown);
        }
        if (sitDown)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            v = 0;
            print("충돌22");
        }
    }

}
