using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MessageInput : NetworkBehaviour
{
    [SerializeField] private Button messageBtn;
    public TMP_InputField messageInput;
    public ChatWindow chatWindow;
    public Player player;

    public override void OnNetworkSpawn()
    {
        chatWindow = FindObjectOfType<ChatWindow>();

        messageInput = GetComponent<TMP_InputField>();
        messageBtn.interactable = false;
        messageBtn.onClick.AddListener(() =>
        {
            chatWindow.AddMessageServerRpc(messageInput.text, player.playerName);
            messageInput.text = "";
        });
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (messageInput.text.Length > 0)
            {
                chatWindow.AddMessageServerRpc(messageInput.text, player.playerName);
                messageInput.text = "";
            }
        }
    }

    public void ValidateMessageLenght()
    {
        if (messageInput.text.Length <= 0)
        {
            messageBtn.interactable = false;
        }
        else
        {
            messageBtn.interactable = true;
        }
    }
}