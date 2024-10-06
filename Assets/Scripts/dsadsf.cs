using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    void Update()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }
}