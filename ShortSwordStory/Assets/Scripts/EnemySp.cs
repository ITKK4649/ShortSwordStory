using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySp : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject EnemyPrefab;
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject GunEnemyPrefab;
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject TPEnemyPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    [SerializeField]
    PlayerStrengthen _playerStrengthen;
    [SerializeField]
    GameManager _gameManager;

    int _randomenemy;
    // 経過時間
    private float time;
    public float timeMax = 1f;

    // Update is called once per frame
    void Update()
    {
        if (_playerStrengthen.shopopen == false)
        {
                // 前フレームからの時間を加算していく
                time = time + Time.deltaTime;

                // 約1秒置きにランダムに生成されるようにする。
                if (time > timeMax)
                {
                    // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                    float x = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Random.Range(rangeA.position.z, rangeB.position.z);
                // GameObjectを上記で決まったランダムな場所に生成
                if (_gameManager._enemyKillCountMax < 200)
                {
                    Instantiate(EnemyPrefab, new Vector3(x, y, z), EnemyPrefab.transform.rotation);
                }
                else if(_gameManager._enemyKillCountMax >= 200 && _gameManager._enemyKillCountMax < 300)
                {
                    _randomenemy = Random.Range(0, 10);
                    if(_randomenemy <= 8)
                    {
                        Instantiate(EnemyPrefab, new Vector3(x, y, z), EnemyPrefab.transform.rotation);
                    }
                    else if (_randomenemy == 9)
                    {
                        Instantiate(GunEnemyPrefab, new Vector3(x, y, z), GunEnemyPrefab.transform.rotation);
                    }
                }
                else if (_gameManager._enemyKillCountMax >= 300)
                {
                    _randomenemy = Random.Range(0, 10);
                    if (_randomenemy <= 7)
                    {
                        Instantiate(EnemyPrefab, new Vector3(x, y, z), EnemyPrefab.transform.rotation);
                    }
                    else if (_randomenemy == 8)
                    {
                        Instantiate(GunEnemyPrefab, new Vector3(x, y, z), GunEnemyPrefab.transform.rotation);
                    }
                    else if (_randomenemy == 9)
                    {
                        Instantiate(TPEnemyPrefab, new Vector3(x, y, z), TPEnemyPrefab.transform.rotation);
                    }
                }

                // 経過時間リセット
                time = 0f;
                }
        }
    }
}