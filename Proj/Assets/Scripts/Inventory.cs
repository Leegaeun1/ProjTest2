using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    public static Inventory Instance;
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;


    public TextMeshProUGUI[] slotText;
    public GameObject bridge;

//#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
//#endif

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        FreshSlot();
        slotText = new TextMeshProUGUI[9];

        for(int i=0; i < 9; i++)
        {
            GameObject textObj = GameObject.Find("num" + (i+1));

            if (textObj != null)
            {
                slotText[i] = textObj.GetComponent<TextMeshProUGUI>();
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slotText[i].text = "0"; // 처음엔 0으로 초기화
            slotText[i].gameObject.SetActive(false);
        }
    }


    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void Check(string name)
    {
        FreshSlot();
        int i = 0;
        for (; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                print("correct");
                if (name.Substring(0, 3) == "log" && "log" == slots[i].item.itemName.Substring(0, 3))
                {
                    print(name);
                    slotText[0].text = (int.Parse(slotText[0].text) + 1).ToString();
                }
                else if (name.Substring(0, 3) == "flo" && name == slots[i].item.itemName) //슬롯과 이름이 같을때만 
                {
                    int slotnum = int.Parse(name.Substring(name.Length - 1, 1));
                    print(slotnum);
                    slotText[slotnum].text = (int.Parse(slotText[slotnum].text) + 1).ToString();
                    break;
                }
            }
        }
        for(i = 0; i < slots.Length; i++) { 

            if (slotText[i].text != "0") //0이 아니면 숫자가 보임
            {
                slotText[i].gameObject.SetActive(true);
            }
            else
            {
                slotText[i].gameObject.SetActive(false);
            }

            if (int.Parse(slotText[i].text) == 5 && slots[i].item.itemName == "log")
            {
                if (!bridge.activeSelf) // 다리가 공개되지 않았을때
                {
                    print("나무를 5개 모았습니다!");
                    bridge.SetActive(true);
                    slotText[i].text = "0";
                }
            }
        }
    }


    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
        }
    }


}
