﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public Transform Destination;       // Gameobject where they will be teleported to
    public string TagList = "|Player|"; // List of all tags that can teleport

    // Use this for initialization
    void Start()
    {
        // As needed
    }

    // Update is called once per frame
    void Update()
    {
        // As needed
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the tag of the colliding object is allowed to teleport
        if (TagList.Contains(string.Format("|{0}|", other.tag)))
        {
            // Update other objects position and rotation
            other.transform.position = Destination.transform.position;
        }
    }
}