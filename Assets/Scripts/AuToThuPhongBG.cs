using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuToThuPhongBG : MonoBehaviour
{
    
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 scaleCuaAnh = transform.localScale; // l?y 3 giá tr? x,y,x c?a scale

        float chieuCaoAnh = sr.bounds.size.y; // L?y chi?u cao c?a bg
        float chieuRongAnh = sr.bounds.size.x; // L?y chi?u r?ng c?a bg

        float chieuCaoCamera = Camera.main.orthographicSize *2f; // L?y chi?u cao c?a camera
        float chieuRongCamera = chieuCaoCamera * Screen.width / Screen.height;

        //float chieuRongCamera = Camera.main.aspect * chieuCaoCamera;

        scaleCuaAnh.y = chieuCaoCamera / chieuCaoAnh;
        scaleCuaAnh.x = chieuRongCamera / chieuRongAnh;

        transform.localScale = scaleCuaAnh; // G?n l?i Scale c?a ?nh bg
    }

 
}
