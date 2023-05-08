using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public event UnityAction<Collider> OnTriggerEnterDo = null;
    void OnTriggerEnter(Collider col)
    {
        if (OnTriggerEnterDo != null)
        {
            OnTriggerEnterDo(col);
        }
    }
}
