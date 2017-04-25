using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour {

    public enum Itemtype
    {
        equip,
        use,
        spell
        
    }
    
    int id;
    Itemtype type;
    string itemName;
    string desc;
    bool dropped;
    Sprite image;
    


    protected virtual void Init()
    {
        string path = "Fonts and Sprits/Items/" + itemName;
        image = Resources.Load<Sprite>(path);
    }

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

    public bool Dropped
    {
        get
        {
            return dropped;
        }

        set
        {
            dropped = value;
        }
    }

    public Sprite vImage
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }
}


public class UseItem : BaseItem
{

    [SerializeField]
    protected int idx;

    [SerializeField]
    protected string itemNamex;

    [SerializeField]
    protected string description;

    [SerializeField]
    protected int uses;

    [SerializeField]
    protected Sprite img;

    public PlayerScript owner;
    protected virtual void OnUse() { }
    public virtual void Use()
    {
        OnUse();
    }
}
