using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NickInput : NetworkBehaviour
{
    [SerializeField] private Button nickBtn;
    public Player player;
    public TMP_InputField nickInput;
    public ConnectedPlayers connectedPlayers;
    public ChatWindow chatWindow;
    public GameObject messageInput;

    public override void OnNetworkSpawn()
    {
        connectedPlayers = FindObjectOfType<ConnectedPlayers>();
        chatWindow = FindObjectOfType<ChatWindow>();

        nickInput = GetComponent<TMP_InputField>();
        nickBtn.interactable = false;
        nickBtn.onClick.AddListener(() =>
        {
            player.SetPlayerName(nickInput.text);
            connectedPlayers.AddPlayerServerRpc(nickInput.text);
            chatWindow.AddMessageServerRpc("Connected!", nickInput.text);
            messageInput.SetActive(true);
            gameObject.SetActive(false);
        });
    } 

    public void ValidateNameLenght()
    {
        if(nickInput.text.Length <= 3)
        {
            nickBtn.interactable = false;
        }
        else
        {
            nickBtn.interactable = true;
        }
    }
}
