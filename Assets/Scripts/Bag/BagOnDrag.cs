using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagOnDrag : MonoBehaviour, IDragHandler
{
    private RectTransform rect;

    private void Awake()
    {
        rect = transform.parent.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;    
    }
}
