using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;

public class NPC : MonoBehaviour
{
    Enemy brain;
    List<Transform> checkPoints;
    // Start is called before the first frame update

    private void Awake()
    {
        this.brain = gameObject.GetComponent<Enemy>();
        GetCheckpoints();
        Debug.LogWarning("Checkpoints gotten");
        this.brain.waypoints = checkPoints;
    }
    void Start()
    {
        // TODO feed waypoints
        // TODO random ship
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
}
