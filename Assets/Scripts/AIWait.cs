using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWait : AIMechanics
{
    public override void MakeState()
    {
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public AIWait(float mechanicTime)
    {
        _mechanicTime = mechanicTime;
        needReload = false;

    }
}
