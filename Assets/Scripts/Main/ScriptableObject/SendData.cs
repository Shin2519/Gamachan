using UnityEngine;

[CreateAssetMenu(fileName = "SendData", menuName = "Scriptable Objects/SendData")]
public class SendData : ScriptableObject
{
    [System.Serializable]
    public struct Total_data
    {
        // 新評価5段階（追加）
        public int Excellent_Count;   // 誤差0
        public int Perfect_Count;     // 誤差1〜500
        public int Great_Count;       // 誤差501〜1000
        public int Good_Count;        // 誤差1001以上
        public int Bad_Count;         // 指定金額未満

        // コイン枚数
        public int c1_count;
        public int c5_count;
        public int c10_count;
        public int c50_count;
        public int c100_count;
        public int c500_count;

        // ボーナス関連
        public int Zero_Count;
        public int Golden_Count;

        // スピードボーナス（必要なら）
        public int Speed_Bonus15;
        public int Speed_Bonus20;

        // お釣り
        public int Total_Change_Amount;

        // コンボ
        public int Combo_Count;
    }

    public Total_data total_Data;
}
