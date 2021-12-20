using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;

namespace Gameplay.controllers
{
    public class RaceController : MonoBehaviour
    {
        public CheckPoint[] checkpoints;
        // Start is called before the first frame update
        void Start()
        {
            foreach (CheckPoint cp in checkpoints)
            {
                cp.isChecked = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

