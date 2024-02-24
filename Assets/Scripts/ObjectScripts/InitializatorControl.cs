using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializatorControl : MonoBehaviour
{
    // Start is called before the first frame update
    protected List<IInitializable> toInitialize;
    [SerializeField]protected string additionalObjectsToLoad = "";
    protected class HollowInitializable : IInitializable{
        public virtual void Initialize(int initializedInOrder)
        {

            Debug.Log("Not IInitializable: " + initializedInOrder.ToString());
        }

    }
    protected void PrepareDefaultObjects()
    {
        toInitialize.Add(GameObject.Find("Player").GetComponent<PlayerBasicControl>());
        toInitialize.Add(GameObject.Find("DialogueRootLoader").GetComponent<DialogueRootLoaderControl>());
        toInitialize.Add(GameObject.Find("DialogueUI").GetComponent<DialoguePlayerControl>());
    }

    protected void PrepareAdditionalObjects()
    {
        string[] splitted = this.additionalObjectsToLoad.Split(";");
        foreach(string objectToLoad in splitted)
        {
            try
            {
                toInitialize.Add(GameObject.Find(objectToLoad).GetComponent<IInitializable>());
            }
            catch
            {
                toInitialize.Add(new HollowInitializable());
            }
        }
        
    }

    protected void InitializeObjects()
    {
        for(int i = 0; i < this.toInitialize.Count; i++)
        {
            Debug.Log(toInitialize.ToString());
            toInitialize[i].Initialize(i);
        }
    }

    void Start()
    {
        toInitialize = new List<IInitializable>();
        PrepareDefaultObjects();
        PrepareAdditionalObjects();
        InitializeObjects();
        GameObject.Find("DialogueUI").SetActive(false);

    }
}
