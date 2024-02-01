using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private GameObject _GameManager;
    private GameManager _gameManager;
    private EnemyManager _enemyManager;
    private GunEnemyManager _gunenemyManager;
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = GameObject.Find("GameManager");
        _gameManager = _GameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemyManager = other.GetComponent<EnemyManager>();
            _enemyManager._enemyHp -= _gameManager._attackDamage * 10;
        }
        if (other.gameObject.CompareTag("GunEnemy"))
        {
            _gunenemyManager = other.GetComponent<GunEnemyManager>();
            _gunenemyManager._gunenemyHp -= _gameManager._attackDamage * 10;
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemyManager = other.GetComponent<EnemyManager>();
            _enemyManager._enemyHp -= _gameManager._attackDamage * 10;
        }
        if (other.gameObject.CompareTag("GunEnemy"))
        {
            _gunenemyManager = other.GetComponent<GunEnemyManager>();
            _gunenemyManager._gunenemyHp -= _gameManager._attackDamage * 10;
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
