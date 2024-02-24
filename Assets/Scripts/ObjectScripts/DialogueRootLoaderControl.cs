using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DialogueRootLoaderControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject dialogueInterface;
    public virtual void Initialize(int initializedInOrder)
    {
        dialogueInterface = GameObject.Find("DialogueUI");
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<ColliderDialogueTriggerControl>().Initialize(initializedInOrder);
        }
    }

    // Update is called once per frame
    public void StartDialogue(XmlDocument doc)
    {
        dialogueInterface.SetActive(true);
        dialogueInterface.GetComponent<DialoguePlayerControl>().PlayDialogue(doc);
    }
}
