using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject selectedPointer;

    // Start is called before the first frame update
    void Start()
    {
        selectedPointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Interact(string name)
    {
        if (name == "select")
        {
            selectedPointer.SetActive(true);
        }
        else if (name == "deselect")
        {
            selectedPointer.SetActive(false);
        }
    }

    public void TakeDamage(int amount)
    {
        print("Arggg! I'm taking damage!");
    }
}
