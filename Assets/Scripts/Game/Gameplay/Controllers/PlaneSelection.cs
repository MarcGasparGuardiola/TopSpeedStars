using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelection : MonoBehaviour
{
    List<PlaneStatistics> planesStatistics;
    // Start is called before the first frame update
    void Start()
    {
        planesStatistics = PlaneList.planesStatistics;

        Debug.Log("Hola");

        if (planesStatistics == null)
        {
            Debug.LogError("Alguna cosa no anat bé al carregar la llista de planes");
        }else
        {
            Debug.Log("Start listing planes");
            // Debug purposes
            foreach (PlaneStatistics plane in planesStatistics)
            {
                Debug.Log(plane.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
