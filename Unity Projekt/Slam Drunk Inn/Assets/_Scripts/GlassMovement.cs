﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovement : MonoBehaviour {

    float speed = 7.5f;

    bool DestroyGameObject = false;
    bool _DestroyGameObject = false;
    float Timer;
    float _Timer;
    float thrust = 5f;



    bool InArea = false;

    GameObject Head;
    Rigidbody2D rb2D;

    //soundkram
    public AudioClip swoosh;
    public AudioClip shatter;
    public AudioClip swallow;
    public AudioSource audio;

	void Start ()
    {
        Timer = 0f;
        _Timer = 0f;
        DestroyGameObject = false;
        _DestroyGameObject = false;
        Head = GameObject.Find("Head");
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //normale vorwärtsbewegung

        if(InArea == true)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                this.transform.parent = Head.transform; //mache glas zum child
                speed = 0f;
                StaticHolder.Drinks++;
                StaticHolder.Combo++;
                StaticHolder.DrunknessCounter++;
                audio.PlayOneShot(swallow, 0.75f);
                rb2D.simulated = false;
                transform.position = new Vector3(-1, 0, 0);
                DestroyGameObject = true;
            }
        }

        if (DestroyGameObject == true)
        {
            Timer += Time.deltaTime;
            if (Timer > .5f)
            {
                //this.transform.parent = null;
                //rb2D.simulated = true;
                //transform.Translate(Vector2.up * thrust * Time.deltaTime);
                Destroy(gameObject);
            }
        }

        if (_DestroyGameObject == true)
        {
            _Timer += Time.deltaTime;
            if (_Timer > 1.5)
            {
                Destroy(gameObject);
            }
        }
    }

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            audio.PlayOneShot(shatter, 0.75f);
            _DestroyGameObject = true;
        }

        if (collision.tag == "Head")
        {
            InArea = true;
        }

        if (collision.tag == "Edge")
        {
            audio.PlayOneShot(swoosh, 0.75f);
        }

        


    }
}
