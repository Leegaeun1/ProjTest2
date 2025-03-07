using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIEvent : MonoBehaviour, IPointerClickHandler
{
    GameObject prevObject;
    GameObject clickedObject;
    TextMeshProUGUI[] slotText;


    private void Start()
    {
        slotText = Inventory.Instance.slotText;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (prevObject != null)
        {
            int num = int.Parse(prevObject.name.Substring(8, 1));
            print(num);


            if (slotText[num-1].gameObject.GetComponent<TextMeshProUGUI>().text != "0")
            {
                prevObject.GetComponent<Image>().color = new Color(255, 255, 255, 1); // 아이템이있다면 ..
            }
            else
            {
                prevObject.GetComponent<Image>().color = new Color(255, 255, 255, 0); // 아이템이없다면 ..
            }
            

        }

        clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(clickedObject.name);
        if (clickedObject.name.Substring(0, 8) == "SlotItem")
        {
            
            clickedObject.GetComponent<Image>().color = new Color(0, 20, 20, 0.07f); // 밝게해줌
            prevObject = clickedObject;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
