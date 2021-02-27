using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Awake() //start보다도 먼저 시작하는 함수
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scalehight = ((float)Screen.width / Screen.height) / ((float) 1080 / 1920); //내가 쓰는 비율 (가로,세로)
        float scalewidth = 1f / scalehight;
        if (scalehight < 1) //위아래 공간이 남는경우
        {
            rect.height = scalehight;
            rect.y = (1f - scalehight) / 2f;
        }
        else //좌우가 남는경우
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
    void OnPreCull() => GL.Clear(true, true, Color.clear); //남는 공간의 색
}
