using UnityEngine;
using UnityEngine.Events;

public class Medkit : MonoBehaviour
{
    public static event UnityAction TakingMedKit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            InvokeTakingMedkit();

/*            Destroy(gameObject);*/
        }
    }

    public static void InvokeTakingMedkit() => TakingMedKit?.Invoke();
}
