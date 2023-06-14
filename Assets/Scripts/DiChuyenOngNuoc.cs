using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiChuyenOngNuoc : MonoBehaviour
{
    public float tocDo;
    private Vector3 buocDiChuyen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DieuKhienBird.instance != null)
            if (DieuKhienBird.instance.flag == true)
                return;
        DiChuyen();
    }

    void DiChuyen()
    {
        buocDiChuyen = transform.position;
        buocDiChuyen.x = buocDiChuyen.x - tocDo * Time.deltaTime;
        transform.position = buocDiChuyen;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HuyDoiTuong"))
        {
            Destroy(gameObject);
        }
    }
}
