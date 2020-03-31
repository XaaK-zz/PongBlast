using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public ponganimation animate;
   
    public bool done;
    public void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("pong");

        animate = g.GetComponent<ponganimation>();
       
    }
    public void buttonPressed()
    {
        animate.pressed = true;
        
        StartCoroutine(Coroutine());
       
    }
    public void LoadScene()
    {
        Debug.Log("loaded");
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
         
    
        
        
        
    
    public void Update()
    {
        if (done == true)
        {
            Debug.Log("loading");
            LoadScene();
            

        }
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(4);
        done = true;
        Debug.Log("done");
    }
}