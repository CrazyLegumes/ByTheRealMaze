using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


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
    bool dropped;
    Sprite image;
    


    protected virtual void Init()
    {
        image = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Fonts and Sprits/Items/" + ItemName + ".png", typeof(Sprite));
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
