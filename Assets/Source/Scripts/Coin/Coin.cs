using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 50;

    public int CoinValue => _coinValue;
}