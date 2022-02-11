using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

public class TestMongoDB
{
    private const string MONGO_URI = "mongodb+srv://Game:EImtn2KAR3pIaP6J@topspeedstars.9lfju.mongodb.net/TopSpeedStars?retryWrites=true&w=majority";
    private const string DATABASE_NAME = "TopSpeedStars";
    private MongoClient client = null;
    private IMongoDatabase db = null;

    public TestMongoDB()
    {
        openConnection();
    }

    private void openConnection() {
        if (client == null) {
            client = new MongoClient(MONGO_URI);
            db = client.GetDatabase(DATABASE_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<PlaneStatistics> initalizePlaneList()
    {
        try
        {
            openConnection();
            IMongoCollection<PlaneStatistics> userCollection = db.GetCollection<PlaneStatistics>("Plane");
            List<PlaneStatistics> userModelList = userCollection.Find(user => true).ToList();
            PlaneStatistics[] userAsap = userModelList.ToArray();
            List<PlaneStatistics> characterList = new List<PlaneStatistics>(); 
            foreach (PlaneStatistics asap in userAsap)
            {
                characterList.Add(asap);
            }
            return characterList;
        }catch(Exception e)
        {
            Debug.LogError(e);
        }
        return null;
    }
}
