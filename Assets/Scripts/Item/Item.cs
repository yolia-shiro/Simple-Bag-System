using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Message")]
    public ItemScriptableObj itemScriptableObj;
    public bool canEquip;
    public bool canUse;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //更新数据
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player.myBag.itemlists.Contains(itemScriptableObj))
            {
                player.myBag.itemlists.Find(e => e == itemScriptableObj).itemCount++;
            }
            else
            {
                for (int i = 0; i < collision.GetComponent<PlayerMovement>().myBag.itemlists.Count; i++)
                {
                    if (player.myBag.itemlists[i] == null)
                    {
                        player.myBag.itemlists[i] = itemScriptableObj;
                        player.myBag.itemlists[i].itemCount++;
                        break;
                    }
                }
            }

            //更新UI
            UIManager.instance.GenerateSlot(player.myBag);
            Destroy(gameObject);
        }
    }
}
