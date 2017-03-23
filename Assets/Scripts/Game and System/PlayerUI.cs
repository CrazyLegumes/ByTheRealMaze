using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    PlayerScript myPlayer;

    GameObject[] healthArray;

    [SerializeField]
    GameObject heartPrefab;

    public Image[] Equipment;



    // Use this for initialization
    void Start()
    {
        
        if (myPlayer != null)
            UpdateTotalHealth();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateTotalHealth()
    {
        if (healthArray != null)
        {
            if (healthArray[0] != null)
            {
                for (int i = 0; i < healthArray.Length; i++)
                {
                    Destroy(healthArray[i]);
                }

            }
        }

        healthArray = new GameObject[myPlayer.mystats.Maxhealth];
        for (int i = 0; i < healthArray.Length; i++)
        {
            healthArray[i] = Instantiate(heartPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            healthArray[i].GetComponent<Graphic>().enabled = false;
        }





        UpdateCurrentHealth();


    }

    public void UpdateCurrentHealth()
    {
        int x, y, count;
        x = y = count = 0;

        foreach (GameObject a in healthArray)
            a.GetComponent<Graphic>().enabled = false;

        for (int i = 0; i < myPlayer.mystats.Health; i++)
        {
            healthArray[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);

            healthArray[i].GetComponent<Graphic>().enabled = true;
            count++;
            if (count >= 6)
            {
                y = 0;
                x -= 100;
                count = 0;
            }
            y = -count * 100;
        }
    }

    public void InsertEquipment(int slot, BaseItem item)
    {
        Equipment[slot].sprite = item.vImage;
        Equipment[slot].preserveAspect = true;
        UpdateEquipment();
        
    }
    public void UpdateEquipment()
    {
        foreach (Image a in Equipment)
        {
            if (a.sprite == null)
                a.GetComponent<Graphic>().enabled = false;
            else
                a.GetComponent<Graphic>().enabled = true;
        }
    }
}
