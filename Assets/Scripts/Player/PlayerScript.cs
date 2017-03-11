using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public StatsClass mystats;






   public bool activeItem = true;


    public BaseItem Item1;
    public BaseItem Item2;

    // Use this for initialization
    [SerializeField]
    int itemCount = 0;

    





    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Item")
        {
            Debug.Log("Hit");
            if (itemCount == 0)
            {
                Item1 = col.GetComponent<BaseItem>();

                
                
            }
            else if(itemCount == 1)
            {
                Item2 = col.GetComponent<BaseItem>();
            }
            col.GetComponent<Renderer>().enabled = false;
            col.enabled = false;
            itemCount++;
        }


    }    


    void Start()
    {
        activeItem = true;
        mystats = new StatsClass();
        InitBaseStats();
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


    }
}
