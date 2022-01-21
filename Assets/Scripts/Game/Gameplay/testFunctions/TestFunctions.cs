using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.controllers;
using Gameplay.actors;
using System;
using System.Linq;

public class TestFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayerToFinishList()
    {

        System.Random rand = new System.Random();
        float randomFloat = (float)rand.NextDouble();
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
       
        string name = (Enumerable.Repeat(chars, 7).Select(s => s[rand.Next(s.Length)]).ToArray()).ToString();

        ResultScene.finishedPlayers.Add((name, randomFloat));
    }
}
