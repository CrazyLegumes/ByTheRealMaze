using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingShadows : MonoBehaviour
{

    List<BoxCollider> hitBoxes = new List<BoxCollider>();
    [SerializeField]
    List<Vector3> visibleArea = new List<Vector3>();
    

    List<RaycastHit> hitObjs = new List<RaycastHit>();
    [SerializeField]
    List<GameObject> hitters = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        StartCoroutine(SweepArea());

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public IEnumerator SweepArea()
    {
        float angle = 0f;
        RaycastHit curr;

        for (; angle < 360;)
        {
            Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)), out curr);
            if (!hitters.Contains(curr.transform.gameObject) && curr.transform.gameObject.tag == "Wall")
            {
                hitObjs.Add(curr);
                hitters.Add(curr.transform.gameObject);

            }

            angle += 15;
            
            

            Debug.DrawRay(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * 2f, Color.red, 100f);
            



        }
        DrawRays();

        Debug.Log(hitObjs.Count);
        yield break;

    }

    void DrawRays()
    {
        Vector3[] points = new Vector3[4];

        foreach (RaycastHit a in hitObjs)
        {
            Vector3 b1 = a.collider.bounds.max;
            Vector3 b2 = a.collider.bounds.min;
            points[0] = new Vector3(b1.x, .5f, b1.z);
            points[1] = new Vector3(b1.x, .5f, b2.z);
            points[2] = new Vector3(b2.x, .5f, b1.z);
            points[3] = new Vector3(b2.x, .5f, b2.z);

            Debug.DrawLine(transform.position, points[0], Color.green, 100f);
            Debug.DrawLine(transform.position, points[1], Color.green, 100f);
            Debug.DrawLine(transform.position, points[2], Color.green, 100f);
            Debug.DrawLine(transform.position, points[3], Color.green, 100f);
            GetPoints(points, a);
        }
        foreach(Vector3 a in visibleArea)
        {
            Debug.DrawLine(transform.position, a, Color.magenta, 100);
        }

    }

    void GetPoints(Vector3[] points, RaycastHit hitpoint)
    {
        SortVector3(points, hitpoint);
        for(int i = 0; i < points.Length; i++)
        {
            
        }
        visibleArea.Add(points[0]);
        visibleArea.Add(points[1]);
        
        
        
        
    }

    void SortVector3(Vector3[] points, RaycastHit hitpoint)
    {
        Vector3 temp;
        for(int i = 1; i < points.Length; i++)
        {
            for(int j = 0; j < points.Length-1; j++)
            {
                if(Vector3.Distance(points[j], hitpoint.point) > Vector3.Distance(points[j + 1], hitpoint.point))
                {
                    temp = points[j];
                    points[j] = points[j+1];
                    points[j+1] = temp;
                }

            }
        }

    }

}
