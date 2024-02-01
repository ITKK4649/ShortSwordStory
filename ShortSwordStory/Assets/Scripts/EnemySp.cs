using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySp : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject EnemyPrefab;
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject GunEnemyPrefab;
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject TPEnemyPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;
    [SerializeField]
    PlayerStrengthen _playerStrengthen;
    [SerializeField]
    GameManager _gameManager;

    int _randomenemy;
    // �o�ߎ���
    private float time;
    public float timeMax = 1f;

    // Update is called once per frame
    void Update()
    {
        if (_playerStrengthen.shopopen == false)
        {
                // �O�t���[������̎��Ԃ����Z���Ă���
                time = time + Time.deltaTime;

                // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
                if (time > timeMax)
                {
                    // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float x = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float y = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float z = Random.Range(rangeA.position.z, rangeB.position.z);
                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
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

                // �o�ߎ��ԃ��Z�b�g
                time = 0f;
                }
        }
    }
}