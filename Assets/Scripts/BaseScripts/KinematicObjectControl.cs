using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KinematicObjectControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    protected GameObject currentGameObject;
    protected Rigidbody2D currentRigidBody;
    protected Vector2 currentVelocity;
    protected bool wasVelocityApplied = true;
    public virtual void Initialize(int initializedInOrder)
    {
        currentGameObject = gameObject;
        currentRigidBody = currentGameObject.GetComponent<Rigidbody2D>();
    }

    protected void ApplyVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
        wasVelocityApplied = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wasVelocityApplied == false)
        {
            currentRigidBody.AddForce(Vector2.right * currentVelocity.x * Time.deltaTime, ForceMode2D.Impulse);
            currentRigidBody.AddForce(Vector2.up * currentVelocity.y * Time.deltaTime, ForceMode2D.Impulse);
            wasVelocityApplied = true;
        }
        
    }
}
