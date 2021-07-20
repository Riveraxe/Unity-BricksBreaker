using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestory : MonoBehaviour
{
    public int Grade = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("zzzzzzzzzzzzzzz");
        Destroy(gameObject,0.01f);
        Grade = Grade + 1;
        Debug.Log(Grade);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
