using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    // This interface must be implemented by every consumable. They must have a consume action
    public abstract class Consumable : MonoBehaviour
    {
        public string NAME;
        public abstract string GetName();
        // This method will be activated when the player uses its item
        public abstract void Consume(Player target);
    }
}
