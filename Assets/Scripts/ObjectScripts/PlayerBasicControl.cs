using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicControl : PhysicalObjectControl, IInitializable
{
    // Initialize is called before the first frame update
    [SerializeField]protected float speed =5f;
    public override void Initialize(int initializedInOrder)
    {
        base.Initialize(initializedInOrder);
        upperSpeedLimit = new Vector2(100,100);
        lowerSpeedLimit = new Vector2(-100, -100);
        stoppingForce = new Vector2(50, 50);
    }
    

    // Update is called once per frame
    protected override void DoPerFrame() 
    {
        AddSpeed(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        isXSpeedApplied = true;
        isYSpeedApplied = true;
        if (Input.GetAxis("Horizontal") == 0)
        {
            isXSpeedApplied = false;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            isYSpeedApplied = false;
        }
    }
}
