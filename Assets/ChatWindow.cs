using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class ChatWindow : NetworkBehaviour
{
    public TMP_Text text;

    public override void OnNetworkSpawn()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    [ServerRpc(RequireOwnership = false)]
    public void AddMessageServerRpc(string message, string playerName)
    {
        text.text += playerName + ": " + message + "\n";
        AddMessageClientRpc(message, playerName);
    }

    [ClientRpc]
    public void AddMessageClientRpc(string message, string playerName)
    {
        this.text.text += playerName + ": " + message + "\n";
    }
}