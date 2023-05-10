using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stated : MonoBehaviour
{
    public UnityEvent onPress;
    public bool pressed = false;

    public virtual void OnPress(bool tf)
    {
        pressed = tf;
        onPress?.Invoke();
    }
}
