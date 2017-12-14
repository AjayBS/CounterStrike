using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManager : NetworkManager {
    private bool firstPlayerJoined;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject playerObj = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        List<Transform> spawnPositions = NetworkManager.singleton.startPositions;

        if(!firstPlayerJoined)
        {
            firstPlayerJoined = true;
            playerObj.transform.position = spawnPositions[0].position;
        }
        else
        {
            playerObj.transform.position = spawnPositions[1].position;
        }

        NetworkServer.AddPlayerForConnection(conn, playerObj, playerControllerId);
        // base.OnServerAddPlayer(conn, playerControllerId);)
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetPortAndAddress()
    {
        NetworkManager.singleton.networkAddress = "localhost";
        NetworkManager.singleton.networkPort = 7777;       
    }

    public void HostGame()
    {
        SetPortAndAddress();
        NetworkManager.singleton.StartHost();
    }

    public void JoinGame()
    {
        SetPortAndAddress();
        NetworkManager.singleton.StartClient();
    }
}
