using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // プレイヤーhp

    public void TakeDamage(int damage)
    {
        health -= damage; // ダメージを受けた時、hp減少
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            // プレイヤーの死亡処理
        }
    }
}
