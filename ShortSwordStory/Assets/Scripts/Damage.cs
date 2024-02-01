using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private GameObject _GameManager;
    private GameManager _gameManager;
    private EnemyManager _enemyManager;
    private TutorialEnemyManager _tutorialenemyManager;
    private GunEnemyManager _gunenemyManager;
    private TpEnemyManager _tpenemyManager;
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
            _tutorialenemyManager = other.GetComponent<TutorialEnemyManager>();
            if (_enemyManager == false)
            {
                _tutorialenemyManager._enemyHp -= _gameManager._attackDamage;
            }
            else
            {
                _enemyManager._enemyHp -= _gameManager._attackDamage;
            }
        }
        if (other.gameObject.CompareTag("GunEnemy"))
        {
            _gunenemyManager = other.GetComponent<GunEnemyManager>();
            _gunenemyManager._gunenemyHp -= _gameManager._attackDamage;
        }
        if (other.gameObject.CompareTag("TpEnemy"))
        {
            _tpenemyManager = other.GetComponent<TpEnemyManager>();
            _tpenemyManager._tpenemyHp -= _gameManager._attackDamage;
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
