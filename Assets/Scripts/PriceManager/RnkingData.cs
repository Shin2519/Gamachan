using UnityEngine;

public class RnkingData : MonoBehaviour
{
    [SerializeField] private Playername pl;
    private bool isRegistered = false;

    public static RnkingData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Register()
    {
        if (isRegistered) return;
        if (RankingManager.Instance == null) return;
        if (pl == null) return;

        RankingManager.Instance.AddScore(
            "Challenge",
            pl.playername,
            pl.playerscor);

        isRegistered = true;
    }
}
