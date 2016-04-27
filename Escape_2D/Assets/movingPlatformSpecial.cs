using UnityEngine;
using System.Collections;

public class movingPlatformSpecial : MonoBehaviour {
    public float speed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;
    private int initialPoint;
    private bool isOn;
    // Use this for initialization
    void Start () {
        initialPoint = pointSelection;
        currentPoint = points[pointSelection];
        isOn = false;
    }
	
    void Update()
    {
        if(isOn){
            Debug.Log("Player on plat");
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * speed);
            if (transform.position == currentPoint.position)
            {
                pointSelection++;
                if (pointSelection == points.Length)
                {
                    pointSelection = 0;
                }
                currentPoint = points[pointSelection];
            }
        }
        else if (!isOn){
            pointSelection = initialPoint;
            currentPoint = points[pointSelection];
            if (transform.position != points[initialPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * speed);
            }
        }
    }

	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            isOn = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            isOn = false;
        }
    }
}
