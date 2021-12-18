using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBg : MonoBehaviour
{
    private float length, startpos;
    GameObject cam;
    public float parallexEffect;

    
    private void Awake()
    {
        
    }
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float dist = (cam.transform.position.x * parallexEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
