using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode leftAttackKey = KeyCode.LeftArrow;  // 左攻撃キー
    public KeyCode rightAttackKey = KeyCode.RightArrow; // 右攻撃キー
    public float attackCooldown = 0.5f;  // 攻撃のクールダウン時間
    private float lastAttackTime;

    private Animator animator; // アニメーターへの参照
    private Collider2D weaponCollider; // Weaponのコライダー

    void Start()
    {
        animator = GetComponent<Animator>();  // アニメーターを取得
        // Weaponオブジェクトのコライダーを取得
        weaponCollider = transform.Find("Weapon").GetComponent<Collider2D>(); 
        weaponCollider.enabled = false;  // 初期状態で無効
    }

    void Update()
    {
        // 左攻撃
        if (Input.GetKeyDown(leftAttackKey) && Time.time >= lastAttackTime + attackCooldown)
        {
            // 左攻撃アニメーションを再生
            animator.SetTrigger("AttackLeft");
            lastAttackTime = Time.time;
        }

        // 右攻撃
        if (Input.GetKeyDown(rightAttackKey) && Time.time >= lastAttackTime + attackCooldown)
        {
            // 右攻撃アニメーションを再生
            animator.SetTrigger("AttackRight");
            lastAttackTime = Time.time;
        }
    }

    // アニメーションイベントから呼び出される関数
    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;  // コライダーを有効化
        Debug.Log("Weapon Collider Enabled"); // コライダーが有効化されたことをログ出力
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;  // コライダーを無効化
        Debug.Log("Weapon Collider Disabled"); // コライダーが無効化されたことをログ出力
    }
}
