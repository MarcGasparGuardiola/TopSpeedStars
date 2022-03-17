using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.controllers;

namespace Gameplay.actors
{

    public class CheckPoint : MonoBehaviour
    {
        public RaceController raceController;
        public int id;
        public void Check()
        {
            // TODO canviar color
            Debug.Log("Checkpoint");

        }
    }
    
}

