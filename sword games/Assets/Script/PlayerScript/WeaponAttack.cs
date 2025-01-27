using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 敵のアニメーションを再生
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(); // 敵が倒されるアニメーションを再生
            }

            // スコアを加算
            ScoreManager.instance.AddScore(1);
        }
    }
}
