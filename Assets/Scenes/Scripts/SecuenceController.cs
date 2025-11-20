using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuenceController : MonoBehaviour
{
    [SerializeField] DOTweenController1 DOtsuperCube;
    [SerializeField] DOTweenController2 DOTbob;


    public void StartSecuence()
    {
        DOtsuperCube.MoveToDestination();
        DOTbob.MovementBob();
    }

    public void RestartSequence()
    {
        DOTbob.ResetPositions();
        DOtsuperCube.ResetPositions();
    }
}
