using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1; // プレイヤーへのダメージ

    // プレイヤーに到達した際の処理
    public void OnReachPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // ダメージを与える
            }
        }

        Destroy(gameObject); // 自分を消す
    }
}
