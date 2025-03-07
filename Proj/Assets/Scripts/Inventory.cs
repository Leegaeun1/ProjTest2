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

        for(int i=1; i < 10; i++)
        {
            GameObject textObj = GameObject.Find("num" + i);

            if (textObj != null)
            {
                slotText[i-1] = textObj.GetComponent<TextMeshProUGUI>();
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slotText[i].text = "0"; // ó���� 0���� �ʱ�ȭ
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
                if (!bridge.activeSelf) // �ٸ��� �������� �ʾ�����
                {
                    print("������ 5�� ��ҽ��ϴ�!");
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
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }


}
