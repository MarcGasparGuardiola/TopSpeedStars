using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class PlaneStatistics
{
    public ObjectId _id { set; get; }
    public string name { set; get; }
    public string description { private set; get; }
    public int speed { private set; get; }
    public int weight { private set; get; }
    public int mannuver { private set; get; }
}
