using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string username;
    public string hermesusername;
    public string apollousername;

    public int maxMessages = 25;

    public GameObject chatPanel;
    public GameObject textObject;

    public TMP_InputField chatBox;

    public Color usernameCol;
    public Color playerMessage;
    public Color info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    public TaskManager taskManager;
    //public bool taskDone;
    //public PlayerProgression progression;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        Invoke("NPCNotif1", 2);
        Invoke("NPCNotif2", 5);
        Invoke("NPCNotif3", 10);
        Invoke("NPCNotif4", 14);
        Invoke("NPCNotif5", 16);
        Invoke("NPCNotif6", 18);
        Invoke("NPCNotif7", 23);
        Invoke("NPCNotif8", 29);
        Invoke("NPCNotif9", 30);
        Invoke("NPCNotif10", 32);
        Invoke("NPCNotif11", 34);
        Invoke("NPCNotif12", 39);
        Invoke("NPCNotif13", 45);
        Invoke("NPCNotif14", 50);
        Invoke("NPCNotif15", 57);
        Invoke("NPCNotif16", 62);
        Invoke("NPCNotif17", 68);
    }

    #region
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
        SendMessageToChat(apollousername + "  i will obliterate you", Message.MessageType.npcMessage);
    }

    void NPCNotif14()
    {
        SendMessageToChat(apollousername + "  charon", Message.MessageType.npcMessage);
    }

    void NPCNotif15()
    {
        SendMessageToChat(apollousername + "  if you cross paths with hermes", Message.MessageType.npcMessage);
    }

    void NPCNotif16()
    {
        SendMessageToChat(apollousername + "  send him to me", Message.MessageType.npcMessage);
    }

    void NPCNotif17()
    {
        SendMessageToChat(apollousername + "  you will be rewarded handsomely", Message.MessageType.npcMessage);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return)) //enter above shift key
            {
                SendMessageToChat(username + "  " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = ""; //reset to empty
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        //if (!chatBox.isFocused)
        //{
        //    //if (Time.time >= time + 1f)
        //    if (taskManager.functionCalled)
        //    {
        //        SendMessageToChat(npcUsername + "  you're lagging mate", Message.MessageType.npcMessage);
        //        //SendMessageToChat(npcUsername + ": " + chatBox.text, Message.MessageType.npcMessage);
        //        //chatBox.text = "if you could only know";
        //        taskManager.functionCalled = false;
        //    }
        //}
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

        GameObject newText = Instantiate(textObject, chatPanel.transform);
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