using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Exit : EventDependent
{
    [Header("References:")]
    private Animator animator;
    public string PlayersTag;
    private new void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayersTag)
        {
            OnWork(true);

            print("Player " + PlayersTag + " is ready");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayersTag)
        {
            OnWork(false);

            print("Player " + PlayersTag + " is ready");
        }
    }

    public override void OnWork(bool tf)
    {
        base.OnWork(tf);
        animator.SetBool("Open", tf);
    }
}
