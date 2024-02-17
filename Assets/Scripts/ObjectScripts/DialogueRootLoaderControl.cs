using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRootLoaderControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    public virtual void Initialize(int initializedInOrder)
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<ColliderEnterTriggerControl>().Initialize(initializedInOrder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
