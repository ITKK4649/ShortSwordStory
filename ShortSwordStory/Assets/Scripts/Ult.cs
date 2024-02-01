using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Ult : MonoBehaviour
{
    private GameObject _player;
    //　旋回するターゲット
    [SerializeField]
    private Transform target;
    //　現在の角度
    private float angle;
    //　回転するスピード
    [SerializeField]
    private float rotateSpeed = 180f;
    //　ターゲットからの距離
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1f, 2f);
    [SerializeField]
    GameObject bullet;
    private float bulletSpeed = 10.0f;
    private float time = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        target = _player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = target.position + Quaternion.Euler(0f, angle, 0f) * distanceFromTarget;
        //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z), Vector3.up);
        //　ユニットの角度を変更
        angle += rotateSpeed * Time.deltaTime;
        //　角度を0～360度の間で繰り返す
        angle = Mathf.Repeat(angle, 360f);

        time -= Time.deltaTime;
        if (time <= 0)
        {
            BallShot();
            time = 0.02f;
        }
    }

    void BallShot()
    {
        GameObject shotObj = Instantiate(bullet, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        //　5秒後に削除
        Destroy(shotObj, 2.5f);
    }
}
