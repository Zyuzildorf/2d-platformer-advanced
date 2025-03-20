using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 50;

    public int HealtAmount => _healthAmount;
}
