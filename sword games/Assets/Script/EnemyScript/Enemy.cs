using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner; // EnemySpawner への参照
    private Animator animator; // アニメーターへの参照
    private bool isDying = false; // 倒される状態を管理
    private Collider2D enemyCollider; // 敵のコライダー

    void Start()
    {
        // EnemySpawner コンポーネントを取得
        enemySpawner = FindObjectOfType<EnemySpawner>();

        animator = GetComponent<Animator>(); // アニメーターを取得
        enemyCollider = GetComponent<Collider2D>(); // 敵のコライダーを取得
    }

    public void TakeDamage()
    {
        if (isDying) return; // すでに倒されている場合は無視

        isDying = true; // 倒された状態に設定

        // アニメーションを再生
        if (animator != null)
        {
            animator.SetTrigger("DieTrigger"); // "DieTrigger"はAnimatorのトリガー
        }

        // コライダーを無効化
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false; // 当たり判定を無効化
        }

        StopMovement();

        // アニメーション終了後に削除（時間はアニメーションの長さに合わせる）
        Destroy(gameObject, 1f); // 1秒後に削除
    }

    private void StopMovement()
    {
        // Transformを用いた移動の場合も速度を停止する
        EnemyMovement movement = GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.enabled = false; // 移動スクリプトを無効化
        }
    }

    void OnDestroy()
    {
        // 敵が破壊されたときに EnemySpawner に通知
        if (enemySpawner != null)
        {
            enemySpawner.OnEnemyDestroyed();
        }
    }
}
