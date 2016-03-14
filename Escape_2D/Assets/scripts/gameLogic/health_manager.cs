using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health_manager : MonoBehaviour {
    public Sprite[] list;
    //public playerController2D playerController2D;
    public Image image;
	// Use this for initialization
	void Start () {
        image.GetComponent<Image>().sprite = list[list.Length-1];
        Debug.Log(playerController2D.health);
	}
	
	// Update is called once per frame
	void Update () {
        //debug: test if health works
        if (Input.GetKeyDown("h"))
        {
            playerController2D.health -= 1;
            Debug.Log(playerController2D.health);
            image.GetComponent<Image>().sprite = list[playerController2D.health];
        }
	}
}
