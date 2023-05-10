using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDependent : MonoBehaviour
{
    [SerializeField]
    public bool isOpened;

    [Header("Buttons to enable")]
    [SerializeField] protected List<Info> connectedStated;
    [Header("Settings:")]
    public bool onlyOneNeeded;

    public UnityEvent<bool> OnOpen;
    protected void Start()
    {
        if (connectedStated.Capacity != 0)
        {
            foreach (Info button in connectedStated)
            {
                button.stated.onPress.AddListener(CheckButtons);
            }
        }
    }

    private protected void CheckButtons()
    {
        bool isAllFalse = true;
        foreach (Info button in connectedStated)
        {
            if (button.stated.pressed != button.set && !onlyOneNeeded)
            {
                OnWork(false);
                return;
            }
            else if (button.stated.pressed == button.set && onlyOneNeeded)
            {
                OnWork(true);
                return;
            }
            else if (button.stated.pressed == button.set && onlyOneNeeded) isAllFalse = false;
        }
        if (onlyOneNeeded)
        {
            OnWork(!isAllFalse);
            return;
        }
        OnWork(true);
        return;
    }
    public virtual void OnWork(bool tf)
    {
        isOpened = tf;
        OnOpen?.Invoke(tf);
    }

    [Serializable]
    protected struct Info
    {
        public Stated stated;
        public bool set;
    }
}
