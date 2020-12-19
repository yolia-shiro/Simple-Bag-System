using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform oldParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //关闭该物体的碰撞检测
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        oldParent = transform.parent;
        transform.position = eventData.position;
        //脱离父级
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Slot物体上挂载的有Slot脚本
        Slot slot = eventData.pointerCurrentRaycast.gameObject == null ? null : eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>();
        Slot oldSlot = oldParent == null ? null : oldParent.GetComponent<Slot>();
        if (slot != null && oldSlot != null)
        {
            //UI更新
            if (UIManager.instance.slotlists[slot.ID].transform.childCount == 0) 
            {
                //预防连续点击拖动物品时报错
                return;
            }
            var temp = UIManager.instance.slotlists[slot.ID].transform.GetChild(0);
            temp.SetParent(oldParent);
            temp.position = oldParent.position;
            transform.SetParent(UIManager.instance.slotlists[slot.ID].transform);
            transform.position = UIManager.instance.slotlists[slot.ID].transform.position;


            //交换数据
            var itemImage = slot.itemImage;
            slot.itemImage = oldSlot.itemImage;
            oldSlot.itemImage = itemImage;
            var itemText = slot.itemText;
            slot.itemText = oldSlot.itemText;
            oldSlot.itemText = itemText;
            var item = slot.bagScriptableObj.itemlists[slot.ID];
            slot.bagScriptableObj.itemlists[slot.ID] = oldSlot.bagScriptableObj.itemlists[oldSlot.ID];
            oldSlot.bagScriptableObj.itemlists[oldSlot.ID] = item;
        }
        else 
        {
            //还原位置
            transform.SetParent(oldParent.transform);
            transform.position = oldParent.transform.position;
        }
        //打开当前拖拽物体的碰撞检测
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
