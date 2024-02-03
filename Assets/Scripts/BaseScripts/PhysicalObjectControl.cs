using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicalObjectControl : KinematicObjectControl
{
    // Start is called before the first frame update
    protected Vector2 upperSpeedLimit;
    protected Vector2 lowerSpeedLimit;
    protected Vector2 stoppingForce;
    public override void Initialize(int initializedInOrder)
    {
        base.Initialize(initializedInOrder);
    }

    // Update is called once per frame
    protected void AddSpeed(float xSpeed, float ySpeed)
    {
        Vector2 addSpeed = Vector2.right *xSpeed + Vector2.up*ySpeed;
        ApplyVelocity(addSpeed);
        float xToCorrect = 0;
        float yToCorrect = 0;
        if (currentRigidBody.velocity.x > upperSpeedLimit.x)
        {
            xToCorrect = upperSpeedLimit.x - currentRigidBody.velocity.x;
            
        }
        if (currentRigidBody.velocity.y > upperSpeedLimit.y)
        {
            yToCorrect = upperSpeedLimit.y - currentRigidBody.velocity.y;

        }

        addSpeed = new Vector2(xToCorrect, yToCorrect);
        ApplyVelocity(addSpeed);

    }

    protected virtual void DoPhysics()
    {
        Vector2 addSpeed = new Vector2();
        float xToCorrect = 0;
        float yToCorrect = 0;
        if (currentRigidBody.velocity.x > upperSpeedLimit.x)
        {
            xToCorrect = upperSpeedLimit.x - currentRigidBody.velocity.x;

        }
        if (currentRigidBody.velocity.y > upperSpeedLimit.y)
        {
            yToCorrect = upperSpeedLimit.y - currentRigidBody.velocity.y;

        }

        if (currentRigidBody.velocity.x < lowerSpeedLimit.x)
        {
            xToCorrect = currentRigidBody.velocity.x - lowerSpeedLimit.x;

        }
        if (currentRigidBody.velocity.y < lowerSpeedLimit.y)
        {
            yToCorrect = currentRigidBody.velocity.y - lowerSpeedLimit.y;

        }

        addSpeed = new Vector2(xToCorrect, yToCorrect);
        ApplyVelocity(addSpeed);
    }

    protected virtual void DoOtherStuff()
    {

    }
    void Update()
    {
        DoPhysics();
        DoOtherStuff();
        
    }
}
