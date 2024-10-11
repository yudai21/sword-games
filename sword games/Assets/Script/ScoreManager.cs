using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // シングルトンとしてのインスタンス

    private int score = 0; // 現在のスコア
    public int scoreTowin = 10; // クリアに必要なスコア

    public void Awake()
    {
        // シングルトンのインスタンス設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ゲームのシーンが変わっても破棄されないようにする
        }
        else
        {
            Destroy(gameObject); // 複数のインスタンスが生成されるのを防ぐ
        }
    }

    // スコアを加算するメソッド
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Current Score: " + score);

        // クリア条件をチェック
        if (score >= scoreTowin)
        {
            Debug.Log("You Win!");
            // クリアした時の処理を追加
        }
    }
}
