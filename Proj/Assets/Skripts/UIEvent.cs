using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour, IPointerClickHandler
{
    GameObject prevObject;
    GameObject clickedObject;
    Inventory text;
    int textNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (prevObject != null)
        {
            prevObject.GetComponent<Image>().color = new Color(255, 255, 255, 0f); // π‡∞‘«ÿ¡‹
        }

        clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(clickedObject.name);
        if (clickedObject.name.Substring(0, 8) == "SlotItem")
        {
            
            clickedObject.GetComponent<Image>().color = new Color(0, 20, 20, 0.07f); // π‡∞‘«ÿ¡‹
            prevObject = clickedObject;
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
