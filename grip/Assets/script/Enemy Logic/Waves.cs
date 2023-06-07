using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Wave
{
    public float waveLeangth;
    public float complitionTime;
    public Enemy[] enemies;
}

[System.Serializable]
public class Enemy
{
    public GameObject enemy;
    public float spawnRate;
}
