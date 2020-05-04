using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIMechanics 
{
    public Transform _transform;
    public float _mechanicTime;
    public bool needReload;
    public abstract void MakeState();
    public abstract void Reload();

   
}
