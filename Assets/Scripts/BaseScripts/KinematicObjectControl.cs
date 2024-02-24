using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KinematicObjectControl : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject currentGameObject;
    protected Rigidbody2D currentRigidBody;
    protected Vector2 currentVelocity;
    protected List<Vector2> currentVelocities;
    protected bool wasVelocityApplied = true;
    public virtual void Init(int initializedInOrder)
    {
        currentGameObject = gameObject;
        currentRigidBody = currentGameObject.GetComponent<Rigidbody2D>();
        currentVelocities = new List<Vector2>();
    }

    protected void ApplyVelocity(Vector2 velocity)
    {

        this.currentVelocities.Add(velocity);
        //this.currentVelocity = velocity;
        wasVelocityApplied = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wasVelocityApplied == false)
        {
            foreach(Vector2 vel in currentVelocities)
            {
                currentRigidBody.AddForce(Vector2.right * vel.x*Time.deltaTime, ForceMode2D.Impulse);
                currentRigidBody.AddForce(Vector2.up * vel.y * Time.deltaTime, ForceMode2D.Impulse);
            }
            currentVelocities = new List<Vector2>();
            wasVelocityApplied = true;
        }
        
    }
}
