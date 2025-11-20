using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenController2 : MonoBehaviour
{
    [Header ("Movimiento Bob")]
    [SerializeField] private Transform movement1B;
    [SerializeField] private Transform movement2B;
    [SerializeField] private Transform movement3B;

    [Header("Movimiento Mel")]
    [SerializeField] private Transform movement1M;
    [SerializeField] private Transform movement2M;
    [SerializeField] private Transform movement3M;
    [SerializeField] private Transform movement4M;

    [Header("GameObjects")]
    [SerializeField] GameObject bob;
    [SerializeField] GameObject mel;

    [Header("Variables")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int numJumps;
    [SerializeField] private float duration;

    private Vector3 firstPositionBob;
    private Vector3 firstPositionMel;
    //creas una variable Sequence para poder trabajarla como objecto
    private Sequence sequence;

    void Start()
    {
        firstPositionBob = bob.transform.position;
        firstPositionMel = mel.transform.position;
    }
    /// <summary>
    /// Secuenia grande de los cubos, bob y mel
    /// </summary>
    public void MovementBob()
    {

        sequence = DOTween.Sequence().
        Append(bob.transform.DOJump(movement1B.position, jumpForce, numJumps, duration / 2))
        .Join(mel.transform.DOJump(movement1M.position, jumpForce, numJumps, duration / 2))
        .Append(bob.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f, RotateMode.LocalAxisAdd))
        .Join(mel.transform.DOJump(movement2M.position, jumpForce, numJumps, duration / 2))
        .Append(bob.transform.DOMove(movement2B.position, duration))
        .Join(mel.transform.DOJump(movement3M.position, jumpForce, numJumps, duration / 2))
        .Append(bob.transform.DOJump(movement3B.position, jumpForce, numJumps, duration / 2))
        .Join(bob.transform.DOLocalRotate(new Vector3(0, -90, 0), 0.1f, RotateMode.LocalAxisAdd))
        .Join(mel.transform.DOJump(movement4M.position, jumpForce, numJumps, duration / 2))
        .Join(mel.transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.LocalAxisAdd));

        //iniciamos la secuencia
        sequence.Play();
    }
    /// <summary>
    /// Creamos este metodo donde si la seceuncia existe y esta activa la matamos
    /// </summary>
    public void ResetPositions()
    {
        if (sequence != null && sequence.IsActive())
        {
            sequence.Kill();
        }
        
        bob.transform.position = firstPositionBob;
        mel.transform.position = firstPositionMel;
    }

}
