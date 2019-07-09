using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "EnemySpawnData")]
public class EnemySpawndata : ScriptableObject
{
    public List<Status> statuses = null;
}
