using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody2D rigid;
    private float pos;
    public GameObject wall;
    private GameObject[] walls = new GameObject[9999]; //거의 무한대
    private GameObject startwall1;
    private GameObject startwall2;
    int i = 0;
    int j = 0;
    float high = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pos = transform.position.y;
        startwall1 = (GameObject)Instantiate(wall, new Vector3(Random.Range(-4.7f, 4.7f), 20f, 0), Quaternion.identity);
        startwall2 = (GameObject)Instantiate(wall, new Vector3(Random.Range(-4.7f, 4.7f), 25.5f, 0), Quaternion.identity);
    }
    void Update()
    {
        if (pos + 5.5f < transform.position.y) //공사이의 간격
        {
            walls[i] = (GameObject)Instantiate(wall, new Vector3(Random.Range(-4.7f, 4.7f), 31f + high, 0), Quaternion.identity); //미리 생성
            pos = transform.position.y;
            i++;
            high += 5.5f;

            if (walls[8 + j])
            {
                Destroy(walls[j]);
                j++;
            }
            if (walls[8])
            {
                Destroy(startwall1);
                Destroy(startwall2);
            }
        }
    }
}
