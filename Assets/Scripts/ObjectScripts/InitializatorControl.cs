using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializatorControl : MonoBehaviour
{
    // Start is called before the first frame update
    protected List<IInitializable> toInitialize;
    [SerializeField]protected string additionalObjectsToLoad = "";
    protected class HollowInitializable : IInitializable{}
    protected void PrepareDefaultObjects()
    {
        toInitialize.Add(GameObject.Find("Player").GetComponent<IInitializable>());
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
            toInitialize[i].Initialize(i);
        }
    }

    void Start()
    {
        toInitialize = new List<IInitializable>();
        GameObject.Find("Player");

    }
}
