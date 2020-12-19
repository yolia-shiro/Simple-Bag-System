using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int ID;
    //所属背包
    public BagScriptableObj bagScriptableObj;
    //所属道具
    public ItemScriptableObj itemScriptableObj;
    public Image itemImage;
    public Text itemText;

    public void SetSlot(BagScriptableObj bagScriptableObj, ItemScriptableObj item, int id)
    {
        itemScriptableObj = item;
        this.bagScriptableObj = bagScriptableObj;
        ID = id;
        if (item == null)
        {
            itemImage.gameObject.SetActive(false);
            itemText.gameObject.SetActive(false);
            return;
        }
        //
        itemImage.gameObject.SetActive(true);
        itemText.gameObject.SetActive(true);
        itemImage.sprite = item.itemImage;
        itemText.text = item.itemCount.ToString();
    }

    public void OnClicked()
    {
        if (itemScriptableObj == null) return;
        UIManager.instance.ShowItemIntrodcue(itemScriptableObj.itemIntroduce);
    }
}
