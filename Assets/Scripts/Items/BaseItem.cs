using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem : MonoBehaviour {

    public enum Itemtype
    {
        equip,
        use,
        
    }
    
    int id;
    Itemtype type;
    string itemName;
    string desc;
    



    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public Itemtype Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Desc
    {
        get
        {
            return desc;
        }

        set
        {
            desc = value;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }


}

[System.Serializable]
public class EquipItem: BaseItem
{


    StatsClass itemStats;

    public StatsClass ItemStats
    {
        get
        {
            return itemStats;
        }

        set
        {
            itemStats = value;
        }
    }
}

[System.Serializable]
public class UseItem: BaseItem
{
    protected void OnUse() { }
}