using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speed = 2.0f;
    public float growthRate = 2.0f;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;
        
        material.color = new Color(50.0f, 1.0f, 0.3f, 50.0f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 5.0f, 5.0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        gameObject.transform.localScale += (Vector3.forward * growthRate * Time.deltaTime);
    }
}
