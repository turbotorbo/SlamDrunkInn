﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadGlasChecker : MonoBehaviour {

    GameObject Glas;
    public GameObject Head;

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if(transform.childCount > 1)
        {
            StaticHolder.IsHoldingGlas = true;
        }
        
        if(transform.childCount <= 1)
        {
            StaticHolder.IsHoldingGlas = false;
        }
	}
}
