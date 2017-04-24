using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTome : UseItem {

    [SerializeField]
    GameObject fireball;

	// Use this for initialization
	void Start () {
        InitStats();
        Debug.Log(vImage.name);
	}
	

    void InitStats()
    {
        ItemName = itemNamex;
        base.Init();
        //img = vImage;
        Desc = description;
        Id = idx;
        uses = 1;
        Type = Itemtype.spell;
    }

    protected override void OnUse()
    {
        if (owner != null)
        {
            ShootFireBall(owner.dir);
            uses--;
        }
        if (uses <= 0)
        {
            owner.DestroyUseItem(this);
        }

    }

    void ShootFireBall(string dir)
    {
        GameObject fire = Instantiate(fireball, owner.transform.position, Quaternion.identity);
        Physics.IgnoreCollision(fire.GetComponent<Collider>(), owner.GetComponent<Collider>());
        FireBall it = fire.GetComponent<FireBall>();
        Debug.Log(it.name);
        switch (dir)
        {
            case "North":
                it.velocity = new Vector3(0, 0, 1);
                fire.transform.GetChild(0).rotation = Quaternion.Euler(65, 0, 90);
                break;
            case "South":
                it.velocity = new Vector3(0, 0, -1);
                fire.transform.GetChild(0).rotation = Quaternion.Euler(65, 0, -90);
                break;
            case "East":
                it.velocity = new Vector3(1, 0, 0);
                fire.transform.GetChild(0).rotation = Quaternion.Euler(65, 0, 0);
                break;
            case "West":
                it.velocity = new Vector3(-1, 0, 0);
                fire.GetComponentInChildren<SpriteRenderer>().flipX = true;
                break;
            default:
                it.velocity = Vector3.zero;
                break;
        }
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
