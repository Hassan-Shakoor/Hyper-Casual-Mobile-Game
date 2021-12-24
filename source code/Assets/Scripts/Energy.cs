using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(80 * Time.deltaTime, 80 * Time.deltaTime, 80 * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerManager.energyNo++;
            FindObjectOfType<AudioManager>().playSound("coinSound");
            Destroy(gameObject);
        }
    }
}
