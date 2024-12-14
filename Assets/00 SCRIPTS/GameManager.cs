using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager Instance;
    public static GameManager insantce => Instance;

    [SerializeField] protected GameObject _player, enemyPrefab;
    public GameObject Player => _player;
    public GameObject EnemyPrefab => enemyPrefab;


    protected Vector2 _oldPos;
    [SerializeField] protected int _minRandom;
    [SerializeField] protected int _maxRandom;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(EnemySpawnAfterTime());
    }


    protected void RandomSpawnEnemy()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 newPos = Vector2.zero;

        do
        { 
            newPos.x = Random.Range(cameraPos.x - screenSize.x - 0.1f, cameraPos.x + screenSize.x + 0.1f);
            newPos.y = Random.Range(cameraPos.y - screenSize.y - 0.1f, cameraPos.y + screenSize.y + 0.1f);

        } while ((newPos.x >= cameraPos.x - screenSize.x && newPos.x <= cameraPos.x + screenSize.x) ||
                 (newPos.y >= cameraPos.y - screenSize.y && newPos.y <= cameraPos.y + screenSize.y) ||
                 Vector2.Distance(_oldPos, newPos) < 2f); 

        _oldPos = newPos;
 
        Instantiate(enemyPrefab, newPos, Quaternion.identity);
    }

    protected IEnumerator EnemySpawnAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minRandom, _maxRandom));

            RandomSpawnEnemy();
        }

    }
}
