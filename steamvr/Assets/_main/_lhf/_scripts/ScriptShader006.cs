using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShader006 : MonoBehaviour {

    private Material mat;
    private float value;
    float speed = 12.5f;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void Update()
    {
        value = Mathf.PingPong(Time.time * speed, 15);
        mat.SetFloat("_Strength", value);
     //   Debug.Log(value);
    }
}
