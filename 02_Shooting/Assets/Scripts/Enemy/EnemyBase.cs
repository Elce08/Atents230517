using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // 위아래로 움직이는 정도 결정
    public float amplitude = 3.0f;

    // 사인 그래프가 한번 왕복하는데 걸리는 시간을 증폭시키는 정도
    public float frequency = 2.0f;

    // 왼쪽으로 이동하는 속도
    public float speed = 1.0f;

    // 시작할 때 높이
    float spawnY;

    // 시작부터 경과시간
    float timeElapsed = 0.0f;

    private void Start()
    {
        spawnY = transform.position.y;      // 시작 높이 저장하기
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime * frequency;  // 사인 함수에서 사용할 파라메터 계산

        // 적이 물결치듯이 움직이게 만들기
        transform.position = new Vector3(
            transform.position.x - Time.deltaTime * speed,  // x는 현재 위치에서 점점 감소시키기
            spawnY + Mathf.Sin(timeElapsed) * amplitude,    // spawnY를 기준으로 sin함수 이용해서 높이 결정
            0);
    }
}
