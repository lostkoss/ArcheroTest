using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Brain
{
    private List<AIMechanics> _AIMechanicList;
    protected int stateIndex;
    private bool _withPattern;

    public void ChooseState()
    {
        if (_withPattern)
        {
            PatternChose();
        }
        else
        {
            RandomChoose();
        }
    }

    public void AddAIMechanic(AIMechanics aIMechanics)
    {
        _AIMechanicList.Add(aIMechanics);
    }
    public Brain(bool withPattern)
    {
        _AIMechanicList = new List<AIMechanics>();
        _withPattern = withPattern;
    }
    public void MakeStateByIndex()
    {
        _AIMechanicList[stateIndex].MakeState();
    }
    public float GetCooldown()
    {
        return _AIMechanicList[stateIndex]._mechanicTime;
    }
    private void RandomChoose()
    {
        stateIndex = Random.Range(0, _AIMechanicList.Count);
        StateReload();
        Debug.Log("State");
    }
    private void PatternChose()
    {
        if(stateIndex >= _AIMechanicList.Count-1)
        {
            stateIndex = 0;
        }
        else
        {
            stateIndex++;
        }
        Debug.Log(stateIndex + " Index");
        StateReload();
    }
    private void StateReload()
    {
        if (_AIMechanicList[stateIndex].needReload)
        {
            _AIMechanicList[stateIndex].Reload();
        }
    }
    
    
}
