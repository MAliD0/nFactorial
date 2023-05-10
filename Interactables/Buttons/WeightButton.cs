using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeightButton :Stated
{
    public Collider2D current; //Current standing object, for avoiding "fake" triggers(when another person runover)
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(current == null)
        {
            print("Press");

            base.OnPress(true);
            animator.SetBool("Pressed", true);
            current = collision;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(current == null)
        {
            print("Press");

            base.OnPress(true);
            animator.SetBool("Pressed", true);
            current = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (current == collision)
        {
            print("Unpress");

            base.OnPress(false);
            animator.SetBool("Pressed", false);
            current = null;
        }
    }
}
