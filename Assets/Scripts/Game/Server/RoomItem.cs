using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    public RoomManager manager;

    private void Start()
    {
        manager = FindObjectOfType<RoomManager>();
    }
    public void SetRoomName(string name)
    {
        roomName.text = name;
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}
