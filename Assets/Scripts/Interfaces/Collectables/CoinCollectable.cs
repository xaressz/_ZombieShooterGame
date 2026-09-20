using UnityEngine;
public class CoinCollectable : MonoBehaviour, ICollectable
{
    private bool coinCollected;
    private void Start()
    {
       coinCollected = false; 
    }
    public void Collect()
    {
        Destroy(gameObject);
        coinCollected = true;
    }
    public bool isCoinCollected()
    {
        return coinCollected;        
    }
}
