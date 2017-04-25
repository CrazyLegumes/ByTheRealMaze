using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTome : UseItem{

    Vector3[] positions;
    [SerializeField]
    GameObject lightning;

    void Start()
    {
        InitStats();
        positions = new Vector3[8];
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



    void GetPositions()
    {

        positions[0] = owner.transform.position + new Vector3(1, 0, 0);
        positions[1] = owner.transform.position + new Vector3(-1, 0, 0);
        positions[2] = owner.transform.position + new Vector3(0, 0, 1);
        positions[3] = owner.transform.position + new Vector3(0, 0, -1);
        positions[4] = owner.transform.position + new Vector3(1, 0, 1);
        positions[5] = owner.transform.position + new Vector3(1, 0, -1);
        positions[6] = owner.transform.position + new Vector3(-1, 0, 1);
        positions[7] = owner.transform.position + new Vector3(-1, 0, -1);
    }
    protected override void OnUse()
    {
        if (owner != null)
        {
            GetPositions();
            CallLightning();
            
            
            uses--;
        }
        if (uses <= 0)
        {
            owner.DestroyUseItem(this);
        }

    }

    void CallLightning()
    {
        GameStateMachine.instance.spellCount++;
        foreach (Vector3 a in positions)
        {
            GameObject light =  Instantiate(lightning, a, Quaternion.identity);
            Physics.IgnoreCollision(light.GetComponent<Collider>(), owner.GetComponent<Collider>());
            Destroy(light, 1.7f);
        }

    }
}
