using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class ConnectedPlayers : NetworkBehaviour
{
    public TMP_Text text;
    public override void OnNetworkSpawn()
    {
        text = GetComponent<TMP_Text>();
        text.text = "Connected Players: \n";
    }

    [ServerRpc(RequireOwnership = false)]
    public void AddPlayerServerRpc(string playerName)
    {
        text.text += playerName + "\n";
        Debug.Log(OwnerClientId + " " + playerName);
        AddPlayerClientRpc(playerName);
    }

    [ClientRpc]
    public void AddPlayerClientRpc(string playerName)
    {
        this.text.text += playerName + "\n";
    }
}
