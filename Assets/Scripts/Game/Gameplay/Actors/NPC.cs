using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;
using Gameplay.controllers;

public class NPC : Player
{
    public int numberId;
    Enemy brain;
    List<Transform> checkPoints;
    // Start is called before the first frame update

    private void Awake()
    {
        username = "CPU";
        this.brain = gameObject.GetComponent<Enemy>();
        GetCheckpoints();
        Debug.LogWarning("Checkpoints gotten");
        this.brain.waypoints = checkPoints;
    }
    void Start()
    {
        // TODO positioning and classification

        // TODO ship stats
        // TODO items
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetCheckpoints()
    {
        checkPoints = new List<Transform>();
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Checkpoint"))
        {
            checkPoints.Add(g.transform);
        }
        checkPoints.Sort(delegate (Transform x, Transform y)
        {
            return x.GetComponent<CheckPoint>().id - y.GetComponent<CheckPoint>().id;
        });
    }

    internal new void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            this.EnterPickUp(other);
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            this.EnterCheckpoint(other);
        }
    }

    internal new void EnterCheckpoint(Collider other)
    {
        // absolutely scuffed stuff mate. Banger.
        ((VsCpuController) raceController).CheckGoal(this, other);
        
    }
}
