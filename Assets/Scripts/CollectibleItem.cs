using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnCollect(player);
            Destroy(gameObject);
        }
    }

    protected abstract void OnCollect(Player player);
}
