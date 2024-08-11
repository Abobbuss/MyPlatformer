using TMPro;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void UpdateTimerDisplay(float timeRemaining)
    {
        _timerText.text = $"{(Mathf.CeilToInt(timeRemaining))} / {_timerText.text.Split('/')[1].Trim()}";
    }
}
