using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;

namespace Gameplay.hud
{
    public class ConsumableHud:MonoBehaviour
    {
        [SerializeField] private Text consumableIndicator = null;

        public void SetConsumableIndicator(Consumable item)
        {
            if (this.consumableIndicator != null)
            {
                // TODO change from name to image
                this.consumableIndicator.GetComponent<Text>().text = item.GetName();
            }
        }
    }
}

