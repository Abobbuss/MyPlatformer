using UnityEngine;
using UnityEngine.Events;

public class Medkit : CollectibleItem
{
    public event UnityAction Taking;

    protected override void OnCollect(Player player)
    {
        player.HealAllHealth();
    }
}
