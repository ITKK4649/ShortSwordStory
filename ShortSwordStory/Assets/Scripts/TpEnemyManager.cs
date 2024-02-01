using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TpEnemyManager : MonoBehaviour
{
    public float _speed;
    private GameObject _player;
    private PlayerStrengthen _playerStrengthen;
    private PlayerManager _playerManager;
    private GameObject _GameManager;
    private GameManager _gameManager;
    public int _tpenemyHp;
    public int _tpCount;
    [SerializeField]
    private Slider _EnemyHpSlider;
    [SerializeField]
    private Text _EnemyHpText;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform tpRangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform tpRangeB;
    public bool heal = false;
    private float _tpTime;
    public float _tpTimeMax = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStrengthen = _player.GetComponent<PlayerStrengthen>();
        _playerManager = _player.GetComponent<PlayerManager>();
        _GameManager = GameObject.Find("GameManager");
        _gameManager = _GameManager.GetComponent<GameManager>();
        _tpenemyHp = _gameManager._tpenemyMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStrengthen.shopopen == false)
        {
            transform.LookAt(_player.transform);
            transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z),
            _speed * Time.deltaTime);
            // �O�t���[������̎��Ԃ����Z���Ă���
            _tpTime = _tpTime + Time.deltaTime;

            // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
            if (_tpTime > _tpTimeMax)
            {
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(tpRangeA.position.x, tpRangeB.position.x);
                // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float z = Random.Range(tpRangeA.position.z, tpRangeB.position.z);
                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                this.transform.position = new Vector3(x, this.transform.position.y, z);
                _tpTimeMax = Random.Range(2, 5);
                // �o�ߎ��ԃ��Z�b�g
                _tpTime = 0f;
            }
        }
        if (_tpenemyHp <= 10 && _tpenemyHp != 0 && _tpCount == 0)
        {
            float x = Random.Range(tpRangeA.position.x, tpRangeB.position.x);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(tpRangeA.position.z, tpRangeB.position.z);
            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            this.transform.position = new Vector3(x, this.transform.position.y, z);
            _tpCount++;
        }
        if (_tpenemyHp <= 0)
        {
            Destroy(this.gameObject);
            _playerManager.exp += Random.Range(1, 10);
            _gameManager._enemyKillCount++;
            _gameManager._enemyKillCountMax++;
        }
        _EnemyHpSlider.value = (float)_tpenemyHp / (float)_gameManager._enemyMaxHp;
        _EnemyHpText.text = _tpenemyHp + "/" + _gameManager._enemyMaxHp;
    }

}
