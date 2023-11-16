using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageLogger
{
    private TMPro.TMP_Text messageText;
    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
    }

}
