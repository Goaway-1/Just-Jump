using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_move : MonoBehaviour
{
    private Rigidbody2D rigid;    
    private float jump_force = 650;
    private float move_force = 300;

    float nexttime = 0.2f;
    float clickrange; //점프 주기 랜덤
    int way; //좌우 설정
    private List<int> list = new List<int>() { 1, 2 };

    public AudioSource jump;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        if(nexttime < Time.time)
        {
            if(transform.position.y < -4f)
            {
                clickrange = Random.Range(0.4f, 0.6f);
            }
            else
            {
                clickrange = Random.Range(0.5f, 1.2f);
            }
            nexttime += clickrange;

            Way(); 

            if (way == 0)
            {
                rigid.velocity = Vector3.zero;
                rigid.AddForce(Vector3.up * jump_force);
                rigid.AddForce(Vector3.right * move_force);
                jump.Play();
            }
            else
            {
                rigid.velocity = Vector3.zero;
                rigid.AddForce(Vector3.up * jump_force);
                rigid.AddForce(Vector3.right * (-1) * move_force);
                jump.Play();
            }
            yield return null;
        }
    }
    private void Way() //좌우 결정
    {
        if (transform.position.x > 5)
        {
            way = 1;
        }
        else if (-5 > transform.position.x)
        {
            way = 0;
        }
        else
        {
            way = Random.Range(0, list.Count); //좌우 결정 
        }
    }
}
