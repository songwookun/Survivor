using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGmaeTime = 2 * 10f;
    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };
    [Header("# Game Object")]
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

    public void GetExp()
    {
        exp++;

        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }

}
