using UnityEngine;

public interface ITouchInteractable
{
    // Start is called before the first frame update
    void TouchInteract()
    {
        Debug.Log("Touched");
    }

    
}
