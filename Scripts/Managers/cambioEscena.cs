using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscena : MonoBehaviour
{
    public string escena;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.LoadScene(escena);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
