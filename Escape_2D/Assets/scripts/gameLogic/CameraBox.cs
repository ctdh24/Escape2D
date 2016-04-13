using UnityEngine;
using System.Collections;

public class CameraBox : MonoBehaviour {

    private BoxCollider2D cameraBounds;
    private Transform player;

	// Use this for initialization
	void Start () {
        cameraBounds = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        aspectRatioChange();
        FollowPlayer();
	}
    void aspectRatioChange()
    {
        //16:10
        if (Camera.main.aspect >= (1.6f) && Camera.main.aspect < (1.7f))
            cameraBounds.size = new Vector2(2.3f, 1.43f);
        //16:9
        if (Camera.main.aspect >= (1.7f) && Camera.main.aspect < (1.8f))
            cameraBounds.size = new Vector2(2.547f, 1.43f);
        //5:4
        if (Camera.main.aspect >= (1.25f) && Camera.main.aspect < (1.3f))
            cameraBounds.size = new Vector2(1.80f, 1.43f);
        //4:3
        if (Camera.main.aspect >= (1.3f) && Camera.main.aspect < (1.4f))
            cameraBounds.size = new Vector2(1.913f, 1.43f);
        //3:2
        if (Camera.main.aspect >= (1.5f) && Camera.main.aspect < (1.6f))
            cameraBounds.size = new Vector2(2.16f, 1.43f);
    }

    void FollowPlayer()
    {
        BoxCollider2D temp;
        if (GameObject.Find("boundary"))
        {
            temp = GameObject.Find("boundary").GetComponent<BoxCollider2D>();
            transform.position = new Vector3(
                Mathf.Clamp(player.position.x, temp.bounds.min.x + cameraBounds.size.x / 2, temp.bounds.max.x - cameraBounds.size.x / 2),
                Mathf.Clamp(player.position.y, temp.bounds.min.y + cameraBounds.size.y / 2, temp.bounds.max.y - cameraBounds.size.y / 2),
                transform.position.z);
        }
    }
}
