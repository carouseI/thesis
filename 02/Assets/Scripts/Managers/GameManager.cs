using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Usernames")]
    public string systemName;
    public string username;
    public string hermesusername;
    public string apollousername;

    [Header("Content Settings")]
    public int maxMessages = 25;

    public GameObject chatContentPanel;
    public GameObject chatText;
    public TMP_InputField chatField;

    public GameObject logContentPanel;
    public GameObject logText;
    public TMP_InputField logField;

    [Header("Text Colour")]
    public Color usernameCol;
    public Color playerMessage;
    public Color info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;

        #region chat
        Invoke("NPCNotif0", 5);
        Invoke("NPCNotif1", 10);
        Invoke("NPCNotif2", 13);
        Invoke("NPCNotif3", 17);
        Invoke("NPCNotif4", 21);
        Invoke("NPCNotif5", 22);
        Invoke("NPCNotif6", 25);
        Invoke("NPCNotif7", 33);
        Invoke("NPCNotif8", 37);
        Invoke("NPCNotif9", 42);
        Invoke("NPCNotif10", 45);
        Invoke("NPCNotif11", 47);
        Invoke("NPCNotif12", 50);
        Invoke("NPCNotif13", 51);
        Invoke("NPCNotif14", 52);
        Invoke("NPCNotif15", 55);
        Invoke("NPCNotif16", 65);
        Invoke("NPCNotif17", 73);
        Invoke("NPCNotif18", 77);
        Invoke("NPCNotif19", 87);
        Invoke("NPCNotif20", 90);
        #endregion

        #region log
        Invoke("SystemNotif0", 0);
        Invoke("SystemNotif1", 0);
        Invoke("SystemNotif2", 0);
        Invoke("SystemNotif3", 0);
        Invoke("SystemNotif4", 0);
        Invoke("SystemNotif5", 0);
        #endregion
    }

    #region chat dialogue
    void NPCNotif0()
    {
        SendMessageToChat("            Master of the Skywalk has entered the chat.", Message.MessageType.info);
    }

    void NPCNotif1()
    {
        SendMessageToChat(hermesusername + "  hello?", Message.MessageType.npcMessage);
    }

    void NPCNotif2()
    {
        SendMessageToChat(hermesusername + "  charon, are you there?", Message.MessageType.npcMessage);
    }

    void NPCNotif3()
    {
        SendMessageToChat(hermesusername + "  ...hello?", Message.MessageType.npcMessage);
    }

    void NPCNotif4()
    {
        SendMessageToChat(hermesusername + "  charob", Message.MessageType.npcMessage);
    }

    void NPCNotif5()
    {
        SendMessageToChat(hermesusername + "  chaorn", Message.MessageType.npcMessage);
    }

    void NPCNotif6()
    {
        SendMessageToChat(hermesusername + "  charon", Message.MessageType.npcMessage);
    }

    void NPCNotif7()
    {
        SendMessageToChat(hermesusername + "  can you collect some wanderers over at styx", Message.MessageType.npcMessage);
    }

    void NPCNotif8()
    {
        SendMessageToChat(hermesusername + "  golden boy's looking for me", Message.MessageType.npcMessage);
    }

    void NPCNotif9()
    {
        SendMessageToChat(hermesusername + "  he just noticed his missing cattle", Message.MessageType.npcMessage);
    }

    void NPCNotif10()
    {
        SendMessageToChat(hermesusername + "  ahAHhahaHAHahaHa", Message.MessageType.npcMessage);
    }

    void NPCNotif11()
    {
        SendMessageToChat(hermesusername + "  scodinpkzfep---", Message.MessageType.npcMessage);
    }

    void NPCNotif12()
    {
        SendMessageToChat(hermesusername + "  -sdpfqvj-zejpfn-dsfnkdpkk", Message.MessageType.npcMessage);
    }

    void NPCNotif13()
    {
        SendMessageToChat("            Master of the Skywalk has left the chat.", Message.MessageType.info);
    }

    void NPCNotif14()
    {
        SendMessageToChat("            Almighty Sun has entered the chat.", Message.MessageType.info);
    }

    void NPCNotif15()
    {
        SendMessageToChat(apollousername + "  i will obliterate you", Message.MessageType.npcMessage);
    }

    void NPCNotif16()
    {
        SendMessageToChat(apollousername + "  charon", Message.MessageType.npcMessage);
    }

    void NPCNotif17()
    {
        SendMessageToChat(apollousername + "  if you cross paths with hermes", Message.MessageType.npcMessage);
    }

    void NPCNotif18()
    {
        SendMessageToChat(apollousername + "  send him to me", Message.MessageType.npcMessage);
    }

    void NPCNotif19()
    {
        SendMessageToChat(apollousername + "  you will be rewarded handsomely", Message.MessageType.npcMessage);
    }

    void NPCNotif20()
    {
        SendMessageToChat("            Almighty Sun has left the chat.", Message.MessageType.info);
    }
    #endregion

    #region log updates
    void SystemNotif0()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }

    void SystemNotif1()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }

    void SystemNotif2()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }

    void SystemNotif3()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }

    void SystemNotif4()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }

    void SystemNotif5()
    {
        SendMessageToLog("            Polites has successfully reincarnated.", Message.MessageType.info);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (chatField.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return)) //enter above shift key
            {
                SendMessageToChat(username + "  " + chatField.text, Message.MessageType.playerMessage);
                chatField.text = ""; //reset to empty
            }
        }
        else
        {
            if (!chatField.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatField.ActivateInputField();
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(chatText, chatContentPanel.transform);
        newMessage.textObject = newText.GetComponent<TMP_Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    public void SendMessageToLog(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(logText, logContentPanel.transform);
        newMessage.textObject = newText.GetComponent<TMP_Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info; //default

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;

            case Message.MessageType.npcMessage:
                color = playerMessage;
                break;
        }

        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        npcMessage,
        info
    }
}