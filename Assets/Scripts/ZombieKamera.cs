using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKamera : MonoBehaviour
{
    public Transform zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.name.Equals("Cube"))
        {
            transform.position = new Vector3(zombie.position.x, 12.5f, zombie.position.z);
            transform.rotation = Quaternion.Euler(zombie.eulerAngles.x, zombie.eulerAngles.y, zombie.eulerAngles.z);
        }
        else
        {
            transform.position = new Vector3(zombie.position.x, 31f, zombie.position.z);
            transform.rotation = Quaternion.Euler(zombie.eulerAngles.x+90f, zombie.eulerAngles.y, zombie.eulerAngles.z);
        }
    }
}
