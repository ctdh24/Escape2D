using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    
    public GameObject plat;
    public float speed;

    //keeps track of current point
    public Transform currentPoint;
    //array of points
    public Transform[] points;

    public int pointSelection;
    // Use this for initialization
    void Start () {
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
        plat.transform.position = Vector3.MoveTowards(plat.transform.position, currentPoint.position, Time.deltaTime * speed);
        if (plat.transform.position == currentPoint.position)
        {
            pointSelection++;
            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
	}
}
