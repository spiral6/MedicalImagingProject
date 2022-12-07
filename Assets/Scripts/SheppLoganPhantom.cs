using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SheppLoganPhantom : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        Ellipse[] Phantom = new Ellipse[10];

        int i = 0;

        TextAsset EllipseValues = Resources.Load<TextAsset>("PhantomEllipses");
        StringReader reader = new StringReader(EllipseValues.text);
        string line;
        line = reader.ReadLine();
        while ((line = reader.ReadLine()) != null)
        {
            // string line = reader.ReadLine();
            string[] items = line.Split(';');

            string name = items[0];

            string[] center_str = items[1].Split(',');
            float[] center = { float.Parse(center_str[0]), float.Parse(center_str[1]), float.Parse(center_str[2]) };

            string[] scale_str = items[2].Split(',');
            float[] scale = { float.Parse(scale_str[0]), float.Parse(scale_str[1]), float.Parse(scale_str[2]) };

            Phantom[i] = new Ellipse(name, center, scale, float.Parse(items[3]), float.Parse(items[4]));
            i++;
        }

        GameObject phantom = new GameObject("Phantom");

        foreach(Ellipse p in Phantom)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = "RuntimeSphere" + p.name;
            go.transform.position = new Vector3(p.center[0], p.center[1], p.center[2] + 1.25f);
            go.transform.localScale = new Vector3(p.scale[0], p.scale[1], p.scale[2]);
            go.transform.eulerAngles = new Vector3(0, 0, p.theta);
            go.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Phantom" + p.name);
            go.transform.SetParent(phantom.transform);
        }

        phantom.transform.localScale = new Vector3(.5f, .5f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
