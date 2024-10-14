using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : SaiMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnCtrl SpawnCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if(this.SpawnCtrl != null) return;
        this.SpawnCtrl = GetComponent<SpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;
        Transform ranPoint = this.SpawnCtrl.SpawnPoints.GetRandom();

        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.SpawnCtrl.Spawner.RandomPrefab();
        Transform obj = this.SpawnCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.SpawnCtrl.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
