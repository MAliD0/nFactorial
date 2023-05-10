using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour, IPhysicAction
{
    [Header("Settings:")]
    public Vector3 unitsToMove;
    public float maxSpeed;

    public bool isReachedTarget{ get; private set;}

    public Vector3 targetPos { get; private set; }

    private void Start()
    {
        targetPos = unitsToMove + transform.position;

        if (this.transform.position != targetPos)
            isReachedTarget = false;
    }
    public void Act(bool tf)
    {
        print("Act");
        isReachedTarget = tf;
    }
    private void FixedUpdate()//I use Fixed update because it's affected by Unity.timeScale, which I've changed for pause mechanic. 
    {
        if (!isReachedTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos - unitsToMove, maxSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, maxSpeed * Time.deltaTime);
        }
    }

}
