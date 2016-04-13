using UnityEngine;
using System.Collections;

public class BoundaryManager : MonoBehaviour {

    private BoxCollider2D managerBounds;
    private Transform playerPos;
    public GameObject boundary;

	// Use this for initialization
	void Start () {
        managerBounds = GetComponent<BoxCollider2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        ManageBounds();
	}

    void ManageBounds()
    {
        if (managerBounds.bounds.min.x < playerPos.position.x && playerPos.position.x < managerBounds.bounds.max.x &&
            managerBounds.bounds.min.y < playerPos.position.y && playerPos.position.y < managerBounds.bounds.max.y)
        {
            boundary.SetActive(true);
        }
        else
            boundary.SetActive(false);
    }
}
