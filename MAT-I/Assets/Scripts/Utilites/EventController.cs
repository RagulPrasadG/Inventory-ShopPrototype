using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController<T>
{
    public Action<T> baseEvent;
    public void AddListener(Action<T> listener)
    {
        baseEvent += listener;
    }
    public void RemoveListener(Action<T> listener)
    {
        baseEvent -= listener;
    }

    public void RaiseEvent(T param)
    {
        baseEvent?.Invoke(param);
    }

}
