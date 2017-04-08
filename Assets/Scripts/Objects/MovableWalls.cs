using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWalls : MonoBehaviour
{
    public int turnsTillmove;
    public int turnsWaited;
    public bool waiting;
    public bool wallDown;

    public List<GameObject> ConnectedWalls = new List<GameObject>();
    public List<GameObject> OppositeWalls = new List<GameObject>();



    void Awake()
    {
        waiting = false;
        turnsWaited = 0;

        
        foreach (GameObject go in OppositeWalls)
        {
            Vector3 tempdest = go.transform.position + Vector3.down + new Vector3(0, -.5f, 0);
            while (go.transform.position != tempdest)
            {
                go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
            }
        }

    }


    public IEnumerator MoveWall()
    {
        if (!waiting)
        {
            turnsTillmove = Random.Range(1, 6);
            waiting = true;
            turnsWaited = 0;
            yield break;
        }
        
        else
        {
            turnsWaited++;
            if (turnsWaited >= turnsTillmove)
            {
                Vector3 tempdest = Vector3.zero;
                Vector3 dest = Vector3.zero;
                Vector3 dest2 = Vector3.zero;
                if (wallDown)
                {
                    RaycastHit phit;
                    int floormask = LayerMask.NameToLayer("floor");
                    if (Physics.Raycast(transform.position, Vector3.up, out phit, 10, ~(1 << floormask)))
                    {
                        yield break;
                    }
                      
                    dest = transform.position + Vector3.up + new Vector3(0, .5f, 0);
                    dest2 = dest + Vector3.down + new Vector3(0, -.5f, 0);
                    while (transform.position != dest)
                    {
                        yield return null;
                        tempdest = new Vector3(transform.position.x, dest.y, transform.position.z);
                        transform.position = Vector3.Lerp(transform.position, tempdest, 5 * Time.deltaTime);

                        foreach (GameObject go in ConnectedWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                            go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                        }
                        foreach (GameObject go in OppositeWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest2.y, go.transform.position.z);
                            go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    dest = transform.position + Vector3.down + new Vector3(0, -.5f, 0);
                    dest2 = dest + Vector3.up + new Vector3(0, .5f, 0);
                    while (transform.position != dest)
                    {
                        yield return null;
                        tempdest = new Vector3(transform.position.x, dest.y, transform.position.z);
                        transform.position = Vector3.Lerp(transform.position, tempdest, 5 * Time.deltaTime);

                        foreach (GameObject go in ConnectedWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                            go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                        }
                        foreach (GameObject go in OppositeWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest2.y, go.transform.position.z);
                            go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                        }
                            
                    }
                }
                wallDown = !wallDown;
                waiting = false;
            }
            
            yield break;

        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
