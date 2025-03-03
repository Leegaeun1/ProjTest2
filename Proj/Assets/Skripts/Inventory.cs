using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

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
        FreshSlot();

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
        for (;i < slots.Length; i++)
        {
            slotText[i].gameObject.SetActive(true);
            if (slots[i].item != null && slots[i].item.itemName == name)
            {
                print("correct");
                slotText[i].text = (int.Parse(slotText[i].text) + 1).ToString();
            }

            if (int.Parse(slotText[i].text) == 5)
            {
                print("나무를 5개 모았습니다!");
                bridge.SetActive(true);
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
