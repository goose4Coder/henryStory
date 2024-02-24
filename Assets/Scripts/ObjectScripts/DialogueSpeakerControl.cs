using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
public class DialogueSpeakerControl : MonoBehaviour, IInitializable, ITouchInteractable
{
    // Start is called before the first frame update
    protected XmlDocument dialogueXML;
    [SerializeField] protected string fileNameToLoad;
    TextAsset dialogueFile;
    public virtual void Initialize(int initializedInOrder)
    {
        dialogueFile = (TextAsset)Resources.Load(fileNameToLoad);
        dialogueXML = new XmlDocument();
        dialogueXML.LoadXml(dialogueFile.text);
    }
    void TouchInteract()
    {
        Debug.Log("Touched");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
