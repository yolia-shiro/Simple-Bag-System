using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Bag Message")]
    public GameObject bag;
    public Transform slotContainer;
    public GameObject slotPrefab;
    //public BagScriptableObj bagScriptableObj;
    public Text itemIntroduce;

    public List<GameObject> slotlists = new List<GameObject>();
    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    public void Start()
    {
        itemIntroduce.text = "";
    }

    public void OperatorBag(BagScriptableObj bagScriptableObj)
    {
        bag.SetActive(!bag.activeInHierarchy);
        if (bag.activeInHierarchy)
        {
            GenerateSlot(bagScriptableObj);
        }
    }

    public void GenerateSlot(BagScriptableObj bagScriptableObj)
    {
        slotlists.Clear();
        for (int i = 0; i < bagScriptableObj.itemlists.Count; i++)
        {
            if (slotContainer.childCount != bagScriptableObj.itemlists.Count)
            {
                GameObject curSlot = Instantiate(slotPrefab, slotContainer);
                curSlot.name = "Slot(" + i.ToString() + ")";
            }
            slotContainer.GetChild(i).GetComponent<Slot>().SetSlot(bagScriptableObj, bagScriptableObj.itemlists[i], i);
            slotlists.Add(slotContainer.GetChild(i).gameObject);
        }
    }

    public void ShowItemIntrodcue(string itemInfo)
    {
        if (itemIntroduce == null) return;
        itemIntroduce.text = itemInfo;
    }
}
