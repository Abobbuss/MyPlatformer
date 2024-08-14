using UnityEngine;

public class Coin : CollectibleItem
{
    [SerializeField] private Animator _animator;

    protected override void OnCollect(Player player)
    {
        // Когда-нибудь реализую сумку с монетами
        // TO DO
    }
}
