using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = this.GetComponent<Animation>();
        animation.Play("chest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
