using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Enemy Destroyed!");
            
            // スコアを加算
            ScoreManager.instance.AddScore(1);
        }
    }
}
