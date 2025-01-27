using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;  // 移動速度（Spawner から設定）
    public bool isLeftSpawn;  // 左からスポーンしたか
    private Vector2 targetPosition;  // プレイヤーの位置
    private Animator animator;  // Animator
    private EnemyAttack enemyAttack; // EnemyAttack への参照

    void Start()
    {
        // プレイヤーの位置をターゲットとして設定
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetPosition = player.transform.position;
        }

        animator = GetComponent<Animator>();

        // EnemyAttack コンポーネントを取得
        enemyAttack = GetComponent<EnemyAttack>();

        // スポーン方向に応じてアニメーションを設定
        if (animator != null)
        {
            if (isLeftSpawn)
            {
                animator.SetTrigger("MoveRight");  // 右向きアニメーション
            }
            else
            {
                animator.SetTrigger("MoveLeft");  // 左向きアニメーション
            }
        }
    }

    void Update()
    {
        // プレイヤーに向かって移動
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 到達時の処理を EnemyAttack に委譲
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (enemyAttack != null)
            {
                enemyAttack.OnReachPlayer(); // 到達時の処理を呼び出す
            }
        }
    }
}
