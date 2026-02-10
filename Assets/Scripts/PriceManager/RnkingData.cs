using UnityEngine;

public class RnkingData : MonoBehaviour
{
    [SerializeField] private Playername pl;
    private bool isRegistered = false;

    private void Start()
    {
        pl.playerscor = 10000;
    }

    void Update()
    {
        if (isRegistered) return;
        if (RankingManager.Instance == null) return;
        if (pl == null) return;

        

        if (Timer.Instance.send)
        {
            RankingManager.Instance.AddScore(
            "Challenge",
            pl.playername,
            pl.playerscor
        );
            isRegistered = true;
        }
        
    }
}
