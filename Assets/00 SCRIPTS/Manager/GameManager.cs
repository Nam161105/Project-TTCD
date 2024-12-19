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
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector2 newPos = Vector2.zero;

        int choose = Random.Range(0, 4);

        switch (choose)
        {
            case 0: 
                newPos.x = cameraPosition.x - screenSize.x - 0.5f;
                newPos.y = Random.Range(cameraPosition.y - screenSize.y, cameraPosition.y + screenSize.y);
                break;
            case 1:
                newPos.x = cameraPosition.x + screenSize.x + 0.5f;
                newPos.y = Random.Range(cameraPosition.y - screenSize.y, cameraPosition.y + screenSize.y);
                break;
            case 2: 
                newPos.x = Random.Range(cameraPosition.x - screenSize.x, cameraPosition.x + screenSize.x);
                newPos.y = cameraPosition.y + screenSize.y + 0.5f;
                break;
            case 3: 
                newPos.x = Random.Range(cameraPosition.x - screenSize.x, cameraPosition.x + screenSize.x);
                newPos.y = cameraPosition.y - screenSize.y - 0.5f;
                break;
        }

        GameObject enemy = ObjectPooling.Instance.GetObject(enemyPrefab.gameObject);
        enemy.transform.position = newPos;
        enemy.SetActive(true);
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
