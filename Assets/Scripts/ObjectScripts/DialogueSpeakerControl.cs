using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
public class DialogueSpeakerControl : MonoBehaviour, IInitializable, ITouchInteractable
{
    // Start is called before the first frame update
    protected XmlDocument dialogueXML;
    protected GameObject dialogueRootLoader;
    [SerializeField] protected string fileNameToLoad;
    TextAsset dialogueFile;
    public virtual void Initialize(int initializedInOrder)
    {
        dialogueFile = (TextAsset)Resources.Load("Dialogues/"+fileNameToLoad);
        dialogueRootLoader = GameObject.Find("DialogueRootLoader");
        dialogueXML = new XmlDocument();
        dialogueXML.LoadXml(dialogueFile.text);
    }
    public virtual void TouchInteract()
    {
        dialogueRootLoader.GetComponent<DialogueRootLoaderControl>().StartDialogue(dialogueXML);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
