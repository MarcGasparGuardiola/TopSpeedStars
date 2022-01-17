using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class Goal : CheckPoint
    {
        private void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
        }
        public new void Check()
        {
            
            // TODO animation o algo
            Debug.Log("Goal");
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}
