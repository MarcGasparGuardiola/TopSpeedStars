using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName = "empty";
    public string description;
    public int speed;
    public int weight;
    public int mannuver;
    public string route;
}
