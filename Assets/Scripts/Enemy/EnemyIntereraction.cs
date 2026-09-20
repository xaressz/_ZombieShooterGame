using UnityEngine;

public class EnemyIntereraction : MonoBehaviour,ICollusion
{
    [SerializeField] private GameObject _player;
    private void Start()
{
    
    if (_player == null) 
    {
        _player = GameObject.FindWithTag("Player");
    }
}
    public void Damage()
    {
       Destroy(_player);
    }

    
}
