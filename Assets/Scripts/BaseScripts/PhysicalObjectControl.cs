using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicalObjectControl : KinematicObjectControl
{
    // Start is called before the first frame update
    protected Vector2 upperSpeedLimit;
    protected Vector2 lowerSpeedLimit;
    protected Vector2 stoppingForce;
    protected bool isXSpeedApplied = false;
    protected bool isYSpeedApplied = false;
    public override void Init(int initializedInOrder)
    {
        base.Init(initializedInOrder);
    }

    // Update is called once per frame
    protected void AddSpeed(float xSpeed, float ySpeed)
    {
        Vector2 addSpeed = new Vector2(xSpeed, ySpeed);
        ApplyVelocity(addSpeed);
        LimitSpeed();
    }


    protected void LimitSpeed()
    {
        Vector2 setSpeed = new Vector2();
        float xCorrected = 0;
        float yCorrected = 0;
        xCorrected = Mathf.Clamp(currentRigidBody.velocity.x, lowerSpeedLimit.x, upperSpeedLimit.x);
        yCorrected = Mathf.Clamp(currentRigidBody.velocity.y, lowerSpeedLimit.y, upperSpeedLimit.y);
        

        setSpeed = new Vector2(xCorrected,yCorrected);
        currentRigidBody.velocity = setSpeed;

    }
    protected void StopWithoutAppliedSpeed()
    {
        Vector2 setSpeed = new Vector2();
        float xCorrected = 0;
        float yCorrected = 0;
        if (isXSpeedApplied == false)
        {
            if (currentRigidBody.velocity.x != 0)
            {
                xCorrected = currentRigidBody.velocity.x/stoppingForce.x;
            }
        }
        if (isYSpeedApplied == false)
        {
            if (currentRigidBody.velocity.y != 0)
            {
                yCorrected = currentRigidBody.velocity.y/stoppingForce.y;

            }
        }

        setSpeed = new Vector2(xCorrected,yCorrected);
        currentRigidBody.velocity = setSpeed;
    }

    protected void DoBasicPhysics()
    {
        StopWithoutAppliedSpeed();
    }

    protected virtual void DoPerFrame()
    {

    }
    void Update()
    {
        DoBasicPhysics();
        DoPerFrame();
        
    }
}
