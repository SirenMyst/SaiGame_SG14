using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward : ObjMovement
{ 
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetMousePosition();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMoveTarget", gameObject);
    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = this.moveTarget.position;
        this.targetPosition.z = 0f;
    }
}
