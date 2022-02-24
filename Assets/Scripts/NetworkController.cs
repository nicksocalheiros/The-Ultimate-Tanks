using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [Header("UI")]
    public GameObject login;
    public GameObject match;
    
    [Header("Player")]
    public InputField inputPlayerName;
    public GameObject myPlayer;
    public string randomPlayerName;

    [Header("Room")]
    public InputField roomName;
    
    void Start()
    {
        randomPlayerName = "Jogador" + Random.Range(1000, 10000);
        inputPlayerName.text = randomPlayerName;

        roomName.text = "Room " + Random.Range(1000, 10000);
        
        login.gameObject.SetActive(true);
        match.gameObject.SetActive(false);
    }

    public void Login()
    {
        if (inputPlayerName.text != "")
        {
            PhotonNetwork.NickName = inputPlayerName.text;            
        }else
        {
            PhotonNetwork.NickName = randomPlayerName;
        }

        PhotonNetwork.ConnectUsingSettings();
        
        login.gameObject.SetActive(false);
    }

    public void ButtonSearchFastMatch()
    {
        PhotonNetwork.JoinLobby();
    }

    public void ButtonCreateRoom()
    {
        string roomNameTemp = roomName.text;
        RoomOptions roomOptions = new RoomOptions() {MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(roomNameTemp, roomOptions, TypedLobby.Default);
    }

    // PunCallbacks
    public override void OnConnected()
    {
        Debug.Log("OnConnected");
    }

    public override void OnConnectedToMaster() 
    {
        Debug.Log("OnConnectedToMaster");
        Debug.Log("Server: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing());
        match.gameObject.SetActive(true);
        //PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string tempRoom = "Room " + Random.Range(1000, 10000);
        PhotonNetwork.CreateRoom(tempRoom);
        Debug.Log("Nome da sala: " + tempRoom);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        Debug.Log("Name Room: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Current Player in Room: " + PhotonNetwork.CurrentRoom.PlayerCount);

        login.gameObject.SetActive(false);
        match.gameObject.SetActive(false);

        Instantiate(myPlayer, myPlayer.transform.position, myPlayer.transform.rotation);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected: " + cause);
    }
}
