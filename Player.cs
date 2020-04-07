using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject Berry;
    private void Awake()
    {
        //nuffit falseks aina alussa
        inventory.nuffAxe = false;
        inventory.nuffLiaani = false;
        inventory.nuffRisu = false;
        inventory.nuffSkin = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            inventory.UseItem(Berry, 1);

        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
