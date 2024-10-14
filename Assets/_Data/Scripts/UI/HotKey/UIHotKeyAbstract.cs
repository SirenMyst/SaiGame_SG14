using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyAbstract : SaiMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl hotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIKeyCtrl();
    }

    protected virtual void LoadUIKeyCtrl()
    {
        if (this.hotKeyCtrl != null) return;
        this.hotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.LogWarning(transform.name + ": LoadItemSlots", gameObject);
    }
}
