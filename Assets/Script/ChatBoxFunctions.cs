using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour
{
    [SerializeField]
    private ContentSizeFitter contentSizeFitter;
    [SerializeField]
    private Text showHideButtonText;
    [SerializeField]
    private Transform messsageParentPanel;
    [SerializeField]
    private GameObject newMessagePrefab;

    bool isChatShowing = false;
    string message = "";

    private void Start()
    {
        ToggleChat();
    }

    public void ToggleChat()
    {
        isChatShowing = !isChatShowing;
        if (isChatShowing)
        {
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            showHideButtonText.text = "Hide Chat";
        }
        else
        {
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
            showHideButtonText.text = "Show Chat";
        }
    }

    public void SetMessage (string message)
    {
        this.message = message; 
    }

    public void ShowMessage()
    {
        if (message != "")
        {
            GameObject clone = Instantiate(newMessagePrefab);
            clone.transform.SetParent(messsageParentPanel);
            clone.transform.SetSiblingIndex(messsageParentPanel.childCount - 2);
            clone.GetComponent<MessageFunctions>().ShowMessage(message);

        }      
    }
}
