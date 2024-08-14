using UnityEngine;

[RequireComponent(typeof(Player))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;

    private Player _player;
    private int _healValue = 1;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _vampirismAbility.HealingCompleted += HealPlayer;
    }

    private void OnDisable()
    {
        _vampirismAbility.HealingCompleted -= HealPlayer;
    }

    private void HealPlayer()
    {
        int healAmount = Mathf.Min(_healValue, _vampirismAbility.DamageDealtToEnemy);
        _player.TakeHeal(healAmount);
    }
}
