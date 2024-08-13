using TMPro;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void OnEnable()
    {
        _vampirismAbility.HealingCompleted += UpdateTimerDisplay;
        _vampirismAbility.ReloadingCompleted += UpdateTimerDisplay;
    }

    private void OnDisable()
    {
        _vampirismAbility.HealingCompleted -= UpdateTimerDisplay;
        _vampirismAbility.ReloadingCompleted -= UpdateTimerDisplay;
    }

    public void UpdateTimerDisplay()
    {
        _timerText.text = $"{(Mathf.CeilToInt(_vampirismAbility.CurrentTimeAbility))} / {_timerText.text.Split('/')[1].Trim()}";
    }
}
