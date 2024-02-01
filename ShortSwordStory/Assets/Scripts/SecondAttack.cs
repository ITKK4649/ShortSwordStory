using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAttack : MonoBehaviour
{
    private GameObject _player;
    private attack _attack;
    private GameObject _GameManager;
    private GameManager _gameManager;
    public float destroycounrt;
    private float destroycounrtmax = 150;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Playerattack");
        _GameManager = GameObject.Find("GameManager");
        _attack = _player.GetComponent<attack>();
        _gameManager = _GameManager.GetComponent<GameManager>();
        this.transform.localRotation = Quaternion.Euler(0, -60, 0);
    }

    // Update is called once per frame
    void Update()
    {
        destroycounrt += _gameManager._attackspeed;
        this.transform.Rotate(0, _gameManager._attackspeed, 0);
        if (destroycounrt >= destroycounrtmax)
        {
            if(_attack.attackcount > 1)
            {
                _attack.attackcount = 0;
            }
            _attack.scAttack = false;
            Destroy(this.gameObject);
        }
    }
}
