using UnityEngine;

public interface ITouchInteractable
{
    // Start is called before the first frame update
    public virtual void TouchInteract()
    {
        Debug.Log("Touched");
    }

    
}
