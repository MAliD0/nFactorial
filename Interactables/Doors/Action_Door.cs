using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Action_Door : EventDependent
{

    public IPhysicAction physicAction;
    public bool safeMode;
    new void Start()
    {
        base.Start();
        physicAction = GetComponent<IPhysicAction>();
        if (physicAction != null) base.OnOpen.AddListener(physicAction.Act);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (safeMode)
        {
            if (collision != null)
            {
                base.OnWork(false);
            }
        }
    }
}
