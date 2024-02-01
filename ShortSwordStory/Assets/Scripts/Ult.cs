using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Ult : MonoBehaviour
{
    private GameObject _player;
    //�@���񂷂�^�[�Q�b�g
    [SerializeField]
    private Transform target;
    //�@���݂̊p�x
    private float angle;
    //�@��]����X�s�[�h
    [SerializeField]
    private float rotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
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
        //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
        transform.position = target.position + Quaternion.Euler(0f, angle, 0f) * distanceFromTarget;
        //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z), Vector3.up);
        //�@���j�b�g�̊p�x��ύX
        angle += rotateSpeed * Time.deltaTime;
        //�@�p�x��0�`360�x�̊ԂŌJ��Ԃ�
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
        //�@5�b��ɍ폜
        Destroy(shotObj, 2.5f);
    }
}
