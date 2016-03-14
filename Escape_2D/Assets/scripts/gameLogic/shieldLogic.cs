using UnityEngine;
using System.Collections;

public class shieldLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // initialPosition = gameObject.transform.localPosition;
        StartCoroutine(shieldTurnOff());
    }
	
	// Update is called once per frame
	void Update () {
        /*if (gameObject.activeSelf)
        {
            StartCoroutine(shieldTurnOff());
        }*/
        
    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Enemy")
            Destroy(enemy.gameObject);
    }

    IEnumerator shieldTurnOff()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        playerController2D.set_shieldOff();
        Destroy(gameObject);
        print(Time.time);
    }
}
