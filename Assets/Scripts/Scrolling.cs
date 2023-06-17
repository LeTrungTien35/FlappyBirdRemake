using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float Speed;
    private Renderer _renderer;
    private Vector2 _saveOffset;
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time * Speed, 1);
        Vector2 offset = new Vector2(x, 0);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
