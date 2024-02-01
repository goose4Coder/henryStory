using UnityEngine;

public interface IInitializable 
{
    // Start is called before the first frame update
    public void Initialize(int initializedInOrder)
    {
        
        Debug.Log("No defined interface at: "+ initializedInOrder.ToString());
    }

}
