using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelDestroyerCommand : MonoBehaviour
{
    private Transform _levelHolder;

    public void Execute()
    {
        _levelHolder = _levelHolder;
    }

    public void Execute()
    {
        Object.Destroy(_levelHolder);
    }
}
