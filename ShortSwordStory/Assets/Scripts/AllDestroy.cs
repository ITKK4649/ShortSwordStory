using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;

public class AllDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("GunEnemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("TpEnemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
