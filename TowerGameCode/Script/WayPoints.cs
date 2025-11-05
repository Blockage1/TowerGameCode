using UnityEngine;

public class WayPoints : MonoBehaviour
{


    public static Transform[] points;// to store the value of the waypoints
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        points = new Transform[transform.childCount]; // this count wht come's under the parent
        for (int i = 0; i < points.Length; i++)
        {
            points[i]  = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
