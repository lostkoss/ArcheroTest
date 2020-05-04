using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Arena",menuName = "Arena")]
[System.Serializable]
public class Arena : ScriptableObject
{
    public List<ArenaInfo> arenaList;
   
}
[System.Serializable]
public class ArenaInfo {
    public List<GameObject> enemiesList;
    public GameObject arenaPrefab;
}

