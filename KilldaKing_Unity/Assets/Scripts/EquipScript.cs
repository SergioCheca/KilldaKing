using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject M_spotSpawn;
    void Start()
    {
        M_spotSpawn = GameObject.Find("Hijo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("weapon"))
        {
           
            if (Input.GetKeyDown(KeyCode.O))
            {
                
                collision.transform.parent = M_spotSpawn.transform.parent;
                collision.transform.position = M_spotSpawn.transform.position;
                collision.transform.rotation = M_spotSpawn.transform.rotation;
            }
        }
    }


}
