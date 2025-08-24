using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime;
    public float maxGmaeTime = 2 * 10f;

    public PoolManager pool;
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime > maxGmaeTime)
            gameTime = maxGmaeTime;

    }

}
