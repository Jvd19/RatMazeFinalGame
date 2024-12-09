using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour

{
    GateScript gate;

    private void Awake()
    {
        
    }

    public SpriteRenderer sr;

    public void GetBumped()
    {
        sr.color = Color.green;
        
        gate = GameObject.Find("Gate").GetComponent<GateScript>();
        gate.OpenGate();
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
