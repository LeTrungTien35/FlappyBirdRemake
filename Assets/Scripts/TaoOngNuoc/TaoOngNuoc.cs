using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaoOngNuoc : MonoBehaviour
{
    [SerializeField] GameObject OngNuoc;
    public float thoiGianTaoOngNuoc;
    private float tinhThoiGian;
    void Start()
    {
        tinhThoiGian = 0;
    }


    private void Update()
    {
        if (DieuKhienBird.instance != null)
            if (DieuKhienBird.instance.flag == true)
                return;
        tinhThoiGian = tinhThoiGian - Time.deltaTime;
        if(tinhThoiGian <= 0)
        {
            Vector3 viTri = OngNuoc.transform.position;
            viTri.y = Random.Range(-2.0f, 2.0f);
            Instantiate(OngNuoc, viTri, Quaternion.identity);
            tinhThoiGian = thoiGianTaoOngNuoc;
        }
    }

   
}
