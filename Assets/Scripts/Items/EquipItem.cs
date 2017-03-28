using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EquipItem : BaseItem
{
    public enum itemPlace
    {
        head,
        torso,
        lefth,
        righth,
        legs
    }


    [SerializeField]
    int id;

    [SerializeField]
    string itemName;

    [SerializeField]
    string description;

    [SerializeField]
    int str;

    [SerializeField]
    int def;

    [SerializeField]
    int hp;

    [SerializeField]

    public itemPlace equipPlace;

    Vector3 top, bot;


    [SerializeField]
    Sprite img;
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


    void Start()
    {
        top = new Vector3(transform.position.x, transform.position.y, transform.position.z + .3f);
        bot = new Vector3(transform.position.x, transform.position.y, transform.position.z - .3f);
        InitStats();
    }

    void InitStats()
    {
        
        
        ItemName = itemName;
        base.Init();
        img = vImage;
        Desc = description;
        Id = id;
        itemStats = new StatsClass();
        itemStats.Strength = str;
        itemStats.Defense = def;
        itemStats.Maxhealth = hp;

        Dropped = false;
        Debug.Log("Cmon Dad");

    }

    void Update()
    {
        
    }
}
