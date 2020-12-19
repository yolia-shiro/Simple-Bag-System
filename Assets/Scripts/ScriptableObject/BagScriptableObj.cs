using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bag", menuName = "Bag/BagList")]
public class BagScriptableObj : ScriptableObject
{
    public List<ItemScriptableObj> itemlists = new List<ItemScriptableObj>();
}
