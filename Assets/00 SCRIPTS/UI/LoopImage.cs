using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImage : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sp;


    private void Update()
    {
        this.Loop();
    }

    protected void Loop()
    {
        Vector3 spritePos = sp.transform.position;
        Vector3 playerPos = GameManager.insantce.Player.transform.position;
        if (Mathf.Abs(playerPos.x - spritePos.x) >= 64)
        {
            spritePos.x = playerPos.x;
        }
        if (Mathf.Abs(playerPos.y - spritePos.y) >= 64)
        {
            spritePos.y = playerPos.y;
        }

        sp.transform.position = spritePos;
    }
}
