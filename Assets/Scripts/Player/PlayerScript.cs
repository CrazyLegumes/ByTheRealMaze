using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public StatsClass mystats;

    [SerializeField]
    public PlayerUI myUi;






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
            else if (itemCount == 1)
            {
                Item2 = col.GetComponent<BaseItem>();
            }
            col.GetComponent<Renderer>().enabled = false;
            col.enabled = false;
            itemCount++;
        }


    }


    void Awake()
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
        mystats.Health = mystats.Maxhealth = 12;
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
            StartCoroutine(CameraShake());
        }


    }

    IEnumerator CameraShake()
    {
        float shakeTimer = .3f;
        float shakeStrength = .2f;
        while (shakeTimer >= 0)
        {
            yield return null;
            Camera.main.transform.localPosition = new Vector3(Random.insideUnitSphere.x * shakeStrength, 19, Random.insideUnitSphere.z * shakeStrength);
            shakeTimer -= Time.deltaTime;
        }
        Camera.main.transform.localPosition = new Vector3(0, 19, 0);
        yield break;
    }



}
