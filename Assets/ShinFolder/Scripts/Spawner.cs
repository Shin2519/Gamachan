using UnityEngine;

public class Spawner : MonoBehaviour
{
    public RectTransform canvas;
    public GameObject dropPrefab;
    public float spawnInterval = 0.1f;
    public float spawnChance = 0.2f;

    public float spawnY = 800f;
    public float minX = -800f;
    public float maxX = 800f;

    void Start()
    {
        InvokeRepeating(nameof(TrySpawn), 0f, spawnInterval);
    }

    void TrySpawn()
    {
        if(Random.value<spawnChance)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(dropPrefab, canvas);

        RectTransform rect = obj.GetComponent<RectTransform>();
        float x = Random.Range(minX, maxX);
        rect.anchoredPosition = new Vector2(x, spawnY);
    }
}
