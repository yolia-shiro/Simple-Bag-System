using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Bag/Item")]
public class ItemScriptableObj : ScriptableObject
{
    public string itemName;     //道具名称
    public Sprite itemImage;    //道具图片
    public int itemCount;       //道具数量
    [TextArea]
    public string itemIntroduce;//道具介绍
}
