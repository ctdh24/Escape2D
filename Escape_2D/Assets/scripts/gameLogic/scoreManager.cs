﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreManager : MonoBehaviour {
    public static int gems;
    Text text;
	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        gems = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + gems;
	}
}
