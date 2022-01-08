using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;


public class TestMongoDB : MonoBehaviour
{
    private const string MONGO_URI = "mongodb+srv://Game:EImtn2KAR3pIaP6J@topspeedstars.9lfju.mongodb.net/TopSpeedStars?retryWrites=true&w=majority";
    private const string DATABASE_NAME = "TopSpeedStars";
    private MongoClient client;
    private IMongoDatabase db;

    // Start is called before the first frame update
    void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
        IMongoCollection<CharacterTest> userCollection = db.GetCollection<CharacterTest>("Character");
        List<CharacterTest> userModelList = userCollection.Find(user => true).ToList();
        CharacterTest[] userAsap = userModelList.ToArray();
        foreach (CharacterTest asap in userAsap)
        {
            print(asap.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
