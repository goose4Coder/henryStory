using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTriggerControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject objectToCall;
    public virtual void Initialize(int initializedInOrder)
    {
        objectToCall = gameObject.transform.GetChild(0).gameObject;
        objectToCall.GetComponent<DialogueSpeakerControl>().Initialize(initializedInOrder);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToCall.GetComponent<DialogueSpeakerControl>().TouchInteract();
    }
}
