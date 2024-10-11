using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // 敵の移動速度
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // 敵が左右どちらから来るか決定（ランダム）
        direction = transform.position.x > 0 ? Vector2.left : Vector2.right;  
    }

    // Update is called once per frame
    void Update()
    {
        // 敵をプレイヤーに向かって移動させる
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         // ゲームオーバー処理
    //         Debug.Log("ゲームオーバー");
    //         Time.timeScale = 0; // ゲームを停止
    //     }
    // }
}
