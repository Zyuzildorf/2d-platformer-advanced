using System;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 50;

    public int HealtAmount => _healthAmount;
    public event Action<Heart> OnCollected;

    public void CallEvent()
    {
        OnCollected?.Invoke(this);
    }
}