using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse
{
    public string name = "";
    public float[] center = new float[3];
    public float[] scale = new float[3];
    public float theta = 0;
    public float gray_level = 0;

    public Ellipse(string name, float[] center, float[] scale, float theta, float gray_level) {
        this.name = name;
        this.center = center;
        this.scale = scale;
        this.theta = theta;
        this.gray_level  = gray_level;
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
