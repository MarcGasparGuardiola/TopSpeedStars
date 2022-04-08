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
    public InputField nameField;
    public GameObject playButton;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItems = new List<RoomItem>();
    public Transform contentObject;

    float roomUpdateInterval = 1.5f;
    float nexUpdateTime;

    public List<PlayerItem> playerItems = new List<PlayerItem>();
    public PlayerItem playerCardPrefab;
    public Transform listParent;

    public PlayerSelectManager psm;
    public PlaneSelection planeSelection;


    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    private void Start()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.LocalPlayer.NickName = "Default";

    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            playButton.SetActive(true);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectToMaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }

    public void CreateRoom()
    {
        if (roomField.text.Length >= 1) { 
            PhotonNetwork.CreateRoom(roomField.text, new RoomOptions() { MaxPlayers = 3, BroadcastPropsChangeToAll = true }); 
        }
    }

    public void JoinRoom(string roomName)
    { 
        Debug.Log(roomName);
        Debug.Log(PhotonNetwork.JoinRoom(roomName));
    }

    public void OnClickedLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");

        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
        psm.ShowPlane();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log(roomList.ToStringFull());
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

    void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItems)
        {
            Destroy(item.gameObject);
        }
        playerItems.Clear();

        if (PhotonNetwork.CurrentRoom == null) return;
        // redundant naming scheme to differentiate Photon.Realtime.Player from Gameplay.Actors.Player
        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem playerItem = Instantiate(playerCardPrefab, listParent);
            playerItem.SetPlayerInfo(player.Value);
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                playerItem.HighlightLocalPlayer();
                
            }
            playerItems.Add(playerItem);
        }
    }

    public void SetLocalPlayerPlane()
    {
        playerProperties["characterName"] = planeSelection.characters[planeSelection.planeId].characterName;
        playerProperties["characterId"] = planeSelection.planeId;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void SetLocalNickname()
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
    }
}
