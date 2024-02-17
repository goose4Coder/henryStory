using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeakerControl : MonoBehaviour, IInitializable, ITouchInteractable
{
    // Start is called before the first frame update
    public virtual void Initialize(int initializedInOrder)
    {
        
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
