﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Wardrove : MonoBehaviour {

    public Sprite openned;
    public Sprite closed;

    private LuggageManager gameManager;
    private SpriteRenderer render;
    private bool open;

    // Use this for initialization
    void Start () {
        this.gameManager = GameObject.FindObjectOfType<LuggageManager>();
        render = gameObject.GetComponent<SpriteRenderer>();
        CloseDoor();
        EnableColliders(false);
    }

    private void OnMouseDown()
    {
        if (!this.gameManager.isInteractable)
            return;

        if (open) CloseDoor();
        else OpenDoor();
    }

    private void EnableColliders(bool flag)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Collider2D collider = child.GetComponent<Collider2D>();
            if (collider) collider.enabled = flag;
        }
    }

    private void CloseDoor()
    {
        open = false;
        this.render.sprite = closed;
        ShowChildObjects(false);
        EnableColliders(false);
    }

    private void OpenDoor()
    {
        open = true;
        this.render.sprite = openned;
        ShowChildObjects(true);
        EnableColliders(true);
        //Tracker: what objects were shown
    }

    private void ShowChildObjects(bool show)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = show;
        }
    }

    public bool isOpen
    {
        get { return this.open; }
    }
}