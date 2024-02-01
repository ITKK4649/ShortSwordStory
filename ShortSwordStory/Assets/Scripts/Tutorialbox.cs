using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialbox : MonoBehaviour
{
    [SerializeField]
    Tutorial _tutorial;
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
        if (other.gameObject.CompareTag("Player"))
        {
            _tutorial.tutorialtextCount++;
            _tutorial.objects[0].SetActive(true);
            _tutorial.objects[1].SetActive(false);
        }
    }
}
