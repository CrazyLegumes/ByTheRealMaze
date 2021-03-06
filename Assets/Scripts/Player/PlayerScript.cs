﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]



public class PlayerScript : MonoBehaviour
{
    public OnTurnEnd myDel; 


    public StatsClass mystats;

    public PlayerUI myUi;
    public List<Buffs> buffList;

    [SerializeField]
    Camera myShake;


    EquipItem[] Equipment = new EquipItem[5];



    public bool activeItem = true;
    public bool useItem = false;
    public string dir = "";


    public UseItem Item1;
    public UseItem Item2;

    public ParticleSystem blood;
    public ParticleSystem enemyKill;
    public ParticleSystem playerKill;
    public Animator anim;

    // Use this for initialization
    [SerializeField]
    int itemCount = 0;



    public GameObject DamagedSound;
    public GameObject AttackSound;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            GameStateMachine.won = true;
            Debug.Log("YOU WON!");
        }

        if (col.tag == "Item")
        {
            BaseItem hit = col.gameObject.GetComponent<BaseItem>();
            if (hit.Dropped == false)
            {
                switch (hit.Type)
                {
                    case BaseItem.Itemtype.equip:
                        EquipItems(hit.GetComponent<EquipItem>());
                        break;

                    case BaseItem.Itemtype.use: case BaseItem.Itemtype.spell:
                        Debug.Log("Hit");
                        EquipUseItem(hit.GetComponent<UseItem>());
                        break;
                }

                col.GetComponent<Renderer>().enabled = false;
                col.enabled = false;
                itemCount++;
            }


        }

        if (col.tag == "Trap")
        {

            Traps activation = col.GetComponent<Traps>();
            Debug.Log(activation.gameObject.name);
            if (!activation.Activated)
            {
                activation.Activator = gameObject.GetComponent<PlayerScript>();
                activation.Activated = true;

                switch (activation.MyEffect)
                {
                    case Traps.effect.debuff:
                        {
                            activation.Debuff.owner = this;
                            myDel += new OnTurnEnd(activation.Debuff.Activate);
                            Debug.Log("POISONED");
                            
                            
                            break;
                        }
                    case Traps.effect.instant:
                        activation.InstantActivation();
                        
                        //myDel += activation.function;
                        
                        Debug.Log(activation.Activator.mystats);
                        Debug.Log("EndMyLife");
                        

                        break;
                }
            }


            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Item")
        {
            BaseItem hit = col.GetComponent<BaseItem>();
            hit.Dropped = false;
        }
        if(col.tag == "Trap" && col.GetComponent<SpikeTrap>() != null)
        {
            col.GetComponent<SpikeTrap>().Reset();
        }

    }

    void Awake()
    {
        myUi.UpdateEquipment();
        activeItem = true;
        mystats = new StatsClass();
        InitBaseStats();

        buffList = new List<Buffs>();
        anim = GetComponentInChildren<Animator>();


        blood = mystats.blood;
        enemyKill = Resources.Load<ParticleSystem>("BloodParticles2");
        playerKill = Resources.Load<ParticleSystem>("BloodParticles3");

        itemCount = 0;
    }

    void InitBaseStats()
    {
        mystats.Strength = 1;
        mystats.Defense = 1;
        mystats.Movespeed = 1;
        mystats.Health = mystats.Maxhealth = 5;
        mystats.SightRange = 10;
        mystats.Dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (activeItem) { }

        if (mystats.Damaged)
        {
            mystats.Damaged = false;
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        float shakeStr = .3f;
        float shakeTimer = .3f;
        Vector3 prevPos = Camera.main.transform.localPosition;
        while (shakeTimer >= 0)
        {
            yield return null;
            Camera.main.transform.localPosition = new Vector3(prevPos.x + Random.insideUnitSphere.x * shakeStr, prevPos.y, prevPos.z + Random.insideUnitSphere.z * shakeStr);
            shakeTimer -= Time.deltaTime;
        }

        Camera.main.transform.localPosition = prevPos;
    }


    void EquipUseItem(UseItem used)
    {
        if(Item1 == null)
        {
            Item1 = used;
            myUi.InsertUseItem(0, used);
            used.GetComponent<Renderer>().enabled = false;
            used.GetComponent<Collider>().enabled = false;
            Item1.owner = gameObject.GetComponent<PlayerScript>();

        }
        else
        {
            Item2 = used;
            myUi.InsertUseItem(1, used);
            used.GetComponent<Renderer>().enabled = false;
            used.GetComponent<Collider>().enabled = false;
            Item2.owner = gameObject.GetComponent<PlayerScript>();
        }
        

    }

    void EquipItems(EquipItem item)
    {
        switch (item.equipPlace)
        {
            case global::EquipItem.itemPlace.head:
                if (Equipment[0] != null)
                    DropItem(Equipment[0]);
                myUi.InsertEquipment(0, item);
                Equipment[0] = item;
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<Collider>().enabled = false;
                break;

            case global::EquipItem.itemPlace.lefth:
                if (Equipment[2] != null)
                    DropItem(Equipment[2]);
                Equipment[2] = item;
                myUi.InsertEquipment(2, item);
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<Collider>().enabled = false;
                break;

            case global::EquipItem.itemPlace.legs:
                if (Equipment[4] != null)
                    DropItem(Equipment[4]);
                Equipment[4] = item;
                myUi.InsertEquipment(4, item);
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<Collider>().enabled = false;
                break;


            case global::EquipItem.itemPlace.righth:
                if (Equipment[3] != null)
                    DropItem(Equipment[3]);
                Equipment[3] = item;
                myUi.InsertEquipment(3, item);
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<Collider>().enabled = false;
                break;

            case global::EquipItem.itemPlace.torso:
                if (Equipment[1] != null)
                    DropItem(Equipment[1]);
                Equipment[1] = item;
                myUi.InsertEquipment(1, item);
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<Collider>().enabled = false;
                break;
        }
        EquipIt(item);
    }

    void EquipIt(EquipItem a)
    {
        Debug.Log(mystats);
        mystats += a.ItemStats;
        mystats.Health += a.ItemStats.Maxhealth;

        Debug.Log(mystats);
        
        myUi.UpdateTotalHealth();
    }

    void UnEquipIt(EquipItem a) {
        Debug.Log(mystats);
        mystats.Health -= a.ItemStats.Maxhealth;
        Debug.Log(a.ItemStats.Maxhealth);

        Debug.Log(mystats);
        mystats -= a.ItemStats;
        myUi.UpdateTotalHealth();
        Debug.Log(mystats);
    }

    void DropItem(EquipItem old)
    {
        GameStateMachine.instance.itemToDrop = old;
        //old.Dropped = true;
        //old.transform.parent.position = transform.position;
        //old.GetComponent<Renderer>().enabled = true;
        //old.GetComponent<Collider>().enabled = true;
        UnEquipIt(old);

    }

    public void DestroyUseItem(UseItem item)
    {
        if (item == Item1)
        {
            myUi.RemoveUseItem(0);
            Destroy(item.gameObject);
            if(Item2 != null)
            {
                Item1 = Item2;
                Item2 = null;
                myUi.SwapUsables();
            }
        }
        else if(item == Item2)
        {
            myUi.RemoveUseItem(1);
            Destroy(item.gameObject);
        }
    }

    public void SwapItems()
    {
        UseItem temp = Item1;
        Item1 = Item2;
        Item2 = temp;
        myUi.SwapUsables();
    }

}
