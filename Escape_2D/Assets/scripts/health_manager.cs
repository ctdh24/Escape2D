using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health_manager : MonoBehaviour {
    public Sprite[] list;
    public playerController2D player;
    public Image image;
	// Use this for initialization
	void Start () {
        image.GetComponent<Image>().sprite = list[list.Length-1];
	}
	
	// Update is called once per frame
	void Update () {
        //debug: test if health works
        /*
        if (Input.GetKeyDown("h"))
        {
            player.health--;
            image.GetComponent<Image>().sprite = list[player.health-1];
        }*/
	}
}
