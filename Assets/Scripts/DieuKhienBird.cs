using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DieuKhienBird : MonoBehaviour
{
    public static DieuKhienBird instance;

    public float lucTacDong;
    private Rigidbody2D rigid;
    private Animator anim;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bay, ping, chet;

    private bool conSong;
    private bool daNhanNut;

    public bool flag;
    public int diemSo;
    void Awake()
    {
        conSong = true;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag == true || transform.position.y >= 4f)
            return;
        DiChuyenBird();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }    

    // cac phuong thuc

    void DiChuyenBird()
    {       
        if(conSong == true)
        {
            if(daNhanNut == true)
            {
                daNhanNut = false;
                rigid.velocity = new Vector2(rigid.velocity.x, lucTacDong);
                audioSource.PlayOneShot(bay);
            }
        }

        if(rigid.velocity.y > 0)
        {
            float doXoay = 0f;
            doXoay = Mathf.Lerp(0, 90, rigid.velocity.y /7);
            transform.rotation = Quaternion.Euler(0, 0, doXoay);
        }else if(rigid.velocity.y < 0)
        {
            float doXoay = 0f;
            doXoay = Mathf.Lerp(0, -90, -rigid.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, doXoay);
        }
        
    }    

    public void NhanNut()
    {
        daNhanNut = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("NenDat") || col.gameObject.CompareTag("OngNuoc"))
        {
            audioSource.PlayOneShot(chet);
            anim.SetTrigger("Died");
            flag = true;
            if(DieuKhienGamePlay.ins != null)
            {
                DieuKhienGamePlay.ins.SetPanelGo(diemSo);
            }
        }    
            
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("TinhDiem"))
        {
            audioSource.PlayOneShot(ping);
            diemSo++;
            DieuKhienGamePlay.ins.SetDiemSo(diemSo);
        }    
    }
}
