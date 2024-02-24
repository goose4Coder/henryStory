using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DialoguePlayerControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject dialogueInterface;
    protected GameObject textDisplayer;
    protected GameObject buttonNext;
    protected GameObject buttonOne;
    protected GameObject buttonTwo;
    protected GameObject buttonThree;
    protected GameObject buttonFour;
    protected int targetNode = 0;
    public virtual void Initialize(int initializedInOrder)
    {
        dialogueInterface = gameObject;
        buttonNext = GameObject.Find("ButtonNext");

    }

    protected void useNode()
    {

    }
    public void StartDialogue(XmlDocument dialogueToPlay)
    {
        XmlNodeList nodes;
        nodes = dialogueToPlay.FirstChild.ChildNodes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
