using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public InputField roomField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItems = new List<RoomItem>();
    public Transform contentObject;

    float roomUpdateInterval = 1.5f;
    float nexUpdateTime;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }



    public void CreateRoom()
    {
        if (roomField.text.Length >= 1) { 
            PhotonNetwork.CreateRoom(roomField.text, new RoomOptions() { MaxPlayers = 3 }); 
        }
    }
    public void JoinRoom(string roomName)
    {
        if (roomField.text.Length >= 1)  PhotonNetwork.JoinRoom(roomName);
    }
    public void OnClickedLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nexUpdateTime)
        {
            UpdateRoomList(roomList);
            nexUpdateTime += roomUpdateInterval;
        }
        
    }

    void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomItem room in roomItems)
        {
            Destroy(room.gameObject);
        }
        roomItems.Clear();
        foreach(RoomInfo room in roomList)
        {
            RoomItem nRoom = Instantiate(roomItemPrefab, contentObject);
            nRoom.SetRoomName(room.Name);
            roomItems.Add(nRoom);
        }
    }
}
