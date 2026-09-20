using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("References")]
   [SerializeField] private CoinCollectable _coinCollectable;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
        }
        else if(other.gameObject.TryGetComponent<IWinable>(out var winable) && _coinCollectable.isCoinCollected())
        {
            winable.OnLevelComplete();
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.TryGetComponent<ICollusion>(out var collusion))
        {
            collusion.Damage();
        }
    }
}
