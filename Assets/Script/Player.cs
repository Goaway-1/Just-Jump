using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float move_force;
    public float jump_force;
    //int a = 0;
    public Text Scoretext;
    public static int score = 0;
    public static bool Stop = false;
    public static int delbanner = 0;
    private Vector2 tpos;

    //Sound
    public AudioSource jump;
    public AudioSource die;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Stop) return;
        StartCoroutine(Move());
        Camera.main.transform.position = new Vector3(0, transform.position.y + 6f, -10f); //카메라
    }
    IEnumerator Move() //움직임 시도
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                tpos = Input.GetTouch(0).position;
                if (touch.phase == TouchPhase.Began)
                {
                    if (tpos.x <= Screen.width / 2)
                    {
                        jump.Play();
                        rigid.velocity = Vector3.zero;
                        rigid.AddForce(Vector3.up * jump_force);
                        rigid.AddForce(Vector3.right * (-1) * move_force);
                    }
                    else if (tpos.x >= Screen.width / 2)
                    {
                        jump.Play();
                        rigid.velocity = Vector3.zero;
                        rigid.AddForce(Vector3.up * jump_force);
                        rigid.AddForce(Vector3.right * move_force);
                    }
                }
            }
            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(Stop == false)
        {
            if (col.gameObject.name == "Wall(Clone)")
            {
                Scoretext.text = (++score).ToString();
            }
            else if (!Stop)
            {
                UI.Now = score;
                rigid.velocity = Vector3.zero;
                Gameover();
            }
        }
    }
    private void Gameover()
    {
        Stop = true;
        die.Play();
        delbanner = 1;
    }
}