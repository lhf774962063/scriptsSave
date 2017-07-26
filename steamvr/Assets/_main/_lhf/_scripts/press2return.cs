using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

//using UnityEngine;
using System.Diagnostics;

public class press2return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void returnFun(string str)
    {
        Process.Start(str);
    }

}
