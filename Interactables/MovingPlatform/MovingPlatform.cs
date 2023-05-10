using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;

    private void OnTriggerEnter2D(Collider2D collision)//Simply compares "targetLayer" and objects layer, and if true makes object("collision") its' child.
    {
        if(1 << collision.gameObject.layer == targetLayer.value)
            collision.transform.SetParent(this.transform);

    }
    private void OnTriggerExit2D(Collider2D collision)//And when object steps out of trigger area de-atach it.
    {
        if (1 << collision.gameObject.layer == targetLayer.value) 
            collision.transform.parent = null;
    }

}
