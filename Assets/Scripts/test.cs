﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    Vector2 tt;
    public LayerMask l;
	// Use this for initialization
	void Start () {
        l = 1 << 11;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            GiveRandomMoveDiretion();
	}
    public Vector2 GiveRandomMoveDiretion()
    {

        Vector2 t=new Vector2();
        bool find = false;

        while (!find)
        {
            t = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, t, 10f, l);
            tt = t;
            if (!hit)
            {
                find = true;
                print("find");

            }

            print("Choosing ... ");
        }
        tt = t;
        print("Choosed " + tt);

        return t;
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + (tt * 10f));
    }
}
