using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KinematicObjectControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject currentGameObject;
    protected Rigidbody2D currentRigidBody;
    public void Initialize(int initializedInOrder)
    {
        currentGameObject = gameObject;
        currentRigidBody = currentGameObject.GetComponent<Rigidbody2D>();
    }

    public void MoveObject(Vector2 velocity)
    {
        currentRigidBody.AddForce(Vector2.right * velocity.x);
        currentRigidBody.AddForce(Vector2.up * velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
