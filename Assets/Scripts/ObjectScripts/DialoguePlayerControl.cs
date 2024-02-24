using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using TMPro;
public class DialoguePlayerControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject dialogueInterface;
    protected GameObject textDisplayer;
    protected GameObject speakerName;
    protected GameObject buttonNext;
    protected GameObject buttonOne;
    protected GameObject buttonTwo;
    protected GameObject buttonThree;
    protected GameObject buttonFour;
    protected XmlNodeList nodes;
    protected XmlNode targetNode;
    protected int targetNodeIndex = 0;
    public virtual void Initialize(int initializedInOrder)
    {
        dialogueInterface = gameObject;
        buttonNext = GameObject.Find("ButtonNext");
        textDisplayer= GameObject.Find("TextOfDialogue");
        speakerName = GameObject.Find("SpeakerName");

    }

    protected void useNode()
    {
        buttonNext.GetComponent<Button>().onClick.RemoveAllListeners();
        targetNode = nodes[targetNodeIndex];
        buttonNext.SetActive(true);
        speakerName.SetActive(true);
        Debug.Log(speakerName.GetComponent<TMP_Text>().text);
        speakerName.GetComponent<TMP_Text>().text = targetNode.Attributes.GetNamedItem("speakerName").Value;
        textDisplayer.GetComponent<TMP_Text>().text = targetNode.Attributes.GetNamedItem("mainText").Value;
        switch (targetNode.Attributes.GetNamedItem("replicaType").Value)
        {
            case "Simple":
                targetNodeIndex += 1;
                buttonNext.GetComponent<Button>().onClick.AddListener(useNode);
                break;
            case "":
                targetNodeIndex += 1;
                buttonNext.GetComponent<Button>().onClick.AddListener(useNode);
                break;
            case "Transition":

                targetNodeIndex = int.Parse(targetNode.Attributes.GetNamedItem("toGoTo").Value.ToString());
                buttonNext.GetComponent<Button>().onClick.AddListener(useNode);
                break;
            case "End":
                buttonNext.GetComponent<Button>().onClick.AddListener(EndDialogue);
                break;
            default:
                targetNodeIndex += 1;
                buttonNext.GetComponent<Button>().onClick.AddListener(useNode);
                break;
        }
    }
    protected void EndDialogue()
    {
        dialogueInterface.SetActive(false);
    }
    public void PlayDialogue(XmlDocument dialogueToPlay)
    {
        targetNodeIndex = 0;
        nodes = dialogueToPlay.FirstChild.ChildNodes;
        useNode();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
