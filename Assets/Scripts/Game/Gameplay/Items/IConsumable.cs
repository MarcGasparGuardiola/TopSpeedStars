using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    // This interface must be implemented by every consumable. They must have a consume action
    public interface IConsumable
    {
        // This method will be activated when the player uses its item
        public void Consume(Plane target);
    }
}

