using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneList : MonoBehaviour
{

    public static List<PlaneStatistics> planesStatistics = new List<PlaneStatistics>();

    // Start is called before the first frame update
    void Start()
    {
        TestMongoDB connection = new TestMongoDB();
        planesStatistics = connection.initalizePlaneList();

        if (planesStatistics == null)
        {
            Debug.LogError("Alguna cosa ha anat malament al carregar les dades de les naus (MongoDb)");
        } else
        {
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
