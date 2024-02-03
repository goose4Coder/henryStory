using UnityEngine;

public interface IInitializable 
{
    // Start is called before the first frame update
    public virtual void Initialize(int initializedInOrder)
    {
        
        Debug.Log("No defined init interface at: "+ initializedInOrder.ToString());
    }

}
