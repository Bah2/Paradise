using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{

    public List<InventorySlot> Container = new List<InventorySlot>();
    public bool nuffSkin=false; //riittävästi skinejä
    public bool nuffAxe=false; //riittävästi axeja
    public bool nuffRisu=false; //riittävästi risuja
    public bool nuffLiaani=false; //riittävästi liaaneja


    public void AddItem(ItemObject _item, int _amount)
    {
        
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }

            
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }

        if (_item.description=="Skin") //onks napattu itemi skini
        {
            Debug.Log("skin");
            for (int i = 0; i < Container.Count; i++) //Luupataan containeri läpi
            {
                if (Container[i].item.description == "Skin" && Container[i].amount > 0) //katotaan onko skinejä kolme tai enemmän
                    nuffSkin = true;
            }
            Debug.Log(nuffSkin);
        }

        if (_item.description=="Axe") //onks napattu itemi axe
        {
            for (int i = 0; i < Container.Count; i++) //Luupataan containeri läpi
            {
                if (Container[i].item.description == "Axe" && Container[i].amount == 1) //katotaan onko axeja yksi tai enemmän
                    nuffAxe = true;
            }
            Debug.Log(nuffAxe);
        }

        if (_item.description == "Risu") //onks napattu itemi risu
        {
            for (int i = 0; i < Container.Count; i++) //Luupataan containeri läpi
            {
                if (Container[i].item.description == "Risu" && Container[i].amount > 1) //katotaan onko risuja seitsemän tai enemmän
                    nuffRisu = true;
            }
            Debug.Log(nuffRisu);
        }

        if (_item.description == "Liaani") //onks napattu itemi liaani
        {
            for (int i = 0; i < Container.Count; i++) //Luupataan containeri läpi
            {
                if (Container[i].item.description == "Liaani" && Container[i].amount > 1) //katotaan onko liaaneja kaksi tai enemmän
                    nuffLiaani = true;
            }
        }

        
    }

    public void UseItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {

            if (Container[i].item == _item)
            {
                Container[i].DecAmount(_amount);
                
                if (Container[i].amount == 0) 
                {
                    Container.Remove(Container[i]);
                    Debug.Log("perse");
                }
                
                break;
            }
            
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

    public void DecAmount(int value)
    {
        amount -= value;
    }
}
