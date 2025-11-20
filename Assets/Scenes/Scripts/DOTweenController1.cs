using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DOTweenController1 : MonoBehaviour
{
    [SerializeField] GameObject superCube;


    [SerializeField] private Transform movementDestination;
    [SerializeField] private float duration;
    [SerializeField] private float jumpForce;
    [SerializeField] private int numJumps;
    private Vector3 firstPositionSC;
    // Start is called before the first frame update
    void Start()
    {
        
        firstPositionSC = superCube.transform.position;

    }
    /// <summary>
    /// Este metodo es para mover al cubo invidual
    /// </summary>
    public void MoveToDestination()
    {
        superCube.transform.DOJump(movementDestination.position, jumpForce, numJumps, duration);
        
    }
    /// <summary>
    /// Resetamos la posicion y matamos la animacion
    /// </summary>
    public void ResetPositions()
    {
        superCube.transform.DOKill();
        superCube.transform.position = firstPositionSC;
    }

}
