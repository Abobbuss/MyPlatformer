using UnityEngine;
using UnityEngine.Events;

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
        _vampirismAbility.OnHealStart += HealPlayer;
    }

    private void OnDisable()
    {
        _vampirismAbility.OnHealStart -= HealPlayer;
    }

    private void HealPlayer()
    {
        _player.Heal(_healValue);
    }
}
