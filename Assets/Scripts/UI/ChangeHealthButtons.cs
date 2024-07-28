using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthButtons : MonoBehaviour
{
    [SerializeField] private Button _healButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Player _player;

    private void Start()
    {
        _healButton.onClick.AddListener(Heal);
        _damageButton.onClick.AddListener(Damage);

    }

    private void Heal() =>
        Medkit.InvokeTakingMedkit();

    private void Damage() =>
        _player.TakeDamage();
}
