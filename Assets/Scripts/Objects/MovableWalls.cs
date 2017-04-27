using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWalls : MonoBehaviour
{
    public int turnsTillmove;
    public int turnsWaited;
    public bool waiting;
    public bool wallDown;
    bool started;

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

    public IEnumerator superCheat()
    {
        Vector3 tempdest = Vector3.zero;
        Vector3 dest = Vector3.zero;
        Vector3 dest2 = Vector3.zero;

        dest = transform.position + new Vector3(0, -1000f, 0);
        dest2 = dest + Vector3.up + new Vector3(0, 0.5f, 0);
        
        while (transform.position != dest)
        {
            yield return null;
            tempdest = new Vector3(transform.position.x, dest.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, tempdest, .05f * Time.deltaTime);

            foreach (GameObject go in ConnectedWalls)
            {
                tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                go.transform.position = Vector3.Lerp(go.transform.position, tempdest, .05f * Time.deltaTime);
            }
            foreach (GameObject go in OppositeWalls)
            {
                tempdest = new Vector3(go.transform.position.x, dest2.y, go.transform.position.z);
                go.transform.position = Vector3.Lerp(go.transform.position, tempdest, .05f * Time.deltaTime);
            }

        }
        
        yield return null;
    }

    public IEnumerator MoveWall()
    {
        if (!started)
        {
          
            started = true;

            if (!waiting)
            {
                turnsTillmove = Random.Range(1, 6);
                waiting = true;
                turnsWaited = 0;
                started = false;
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
                        Vector3 veloc_1 = Vector3.Normalize(dest - transform.position) * 5 * (Time.deltaTime);
                        int loop = 0;

                        while (Vector3.Distance(transform.position, dest) > .2f)
                        {
                            loop++;

                            yield return null;
                            tempdest = new Vector3(transform.position.x, dest.y, transform.position.z);
                            transform.position += veloc_1;

                            foreach (GameObject go in ConnectedWalls)
                            {
                                tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                                go.transform.position += veloc_1;
                            }
                            foreach (GameObject go in OppositeWalls)
                            {
                                tempdest = new Vector3(go.transform.position.x, dest2.y, go.transform.position.z);
                                go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                            }
                            if (loop >= 10) break;


                        }
                        transform.position = dest;
                        foreach (GameObject go in ConnectedWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                            go.transform.position = tempdest;

                        }
                    }
                    else
                    {
                        dest = transform.position + Vector3.down + new Vector3(0, -.5f, 0);
                        dest2 = dest + Vector3.up + new Vector3(0, .5f, 0);
                        Vector3 veloc_1 = Vector3.Normalize(dest - transform.position) * 5 * (Time.deltaTime);
                        int loop = 0;
                        while (Vector3.Distance(transform.position, dest) > .2f)
                        {
                            loop++;
                            yield return null;
                            tempdest = new Vector3(transform.position.x, dest.y, transform.position.z);
                            transform.position += veloc_1;  // Vector3.Lerp(transform.position, tempdest, 5 * Time.deltaTime);

                            foreach (GameObject go in ConnectedWalls)
                            {
                                tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                                go.transform.position += veloc_1; //Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                            }
                            foreach (GameObject go in OppositeWalls)
                            {
                                tempdest = new Vector3(go.transform.position.x, dest2.y, go.transform.position.z);
                                go.transform.position = Vector3.Lerp(go.transform.position, tempdest, 5 * Time.deltaTime);
                            }
                            if (loop >= 10) break;

                        }
                        transform.position = dest;
                        foreach (GameObject go in ConnectedWalls)
                        {
                            tempdest = new Vector3(go.transform.position.x, dest.y, go.transform.position.z);
                            go.transform.position = tempdest;
                        }

                    }
                    wallDown = !wallDown;
                    waiting = false;
                }
                started = false;

                yield break;

            }
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
