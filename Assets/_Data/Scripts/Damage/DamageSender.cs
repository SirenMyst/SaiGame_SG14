using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform ojb)
    {
        DamageReciever damageReceiver = ojb.GetComponentInChildren<DamageReciever>();
        if (damageReceiver == null ) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();

    }

    public virtual void Send(DamageReciever damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
     
    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impactOne;
    }
}
