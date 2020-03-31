using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastbutton : MonoBehaviour
{
    public blast animate;
   
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("blast");

        animate = g.GetComponent<blast>();
    }

    public void onButton()
    {
        animate.pressed = true;
    }
}
