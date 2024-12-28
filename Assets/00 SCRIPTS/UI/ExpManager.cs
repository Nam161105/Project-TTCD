using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    protected static ExpManager instance;   
    public static ExpManager Instance => instance;

    [SerializeField] protected float currentExp;
    [SerializeField] protected float maxExp;
    [SerializeField] protected Text levelText;
    [SerializeField] protected Image fillExp;
    [SerializeField] protected GameObject newSkill;
    protected int level = 1;
    public int Level => level;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LevelSystem()
    {
        currentExp += 6;
        if(currentExp >= maxExp)
        {
            maxExp += 12;
            currentExp = 0;
            level++;
            this.LevelUpManager();
            levelText.text = "LV: " + level.ToString();

        }
        fillExp.fillAmount = currentExp / maxExp;
    }

    protected void LevelUpManager()
    {
        if (level == 2)
        {
            StartCoroutine(LevelUpAfterTime());
        }
        if(level == 5)
        {
            StartCoroutine(LevelUpAfterTime2());
        }
    }


    protected IEnumerator LevelUpAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        newSkill.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(SkillAfterTime());
    }

    protected IEnumerator SkillAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameManager.insantce.Player;
        if (player != null)
        {
            NormalAtk normal = player.GetComponent<NormalAtk>();
            normal.enabled = true;
        }
    }

    protected IEnumerator LevelUpAfterTime2()
    {
        yield return new WaitForSeconds(0.1f);
        newSkill.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(SkillAfterTime2());
    }

    protected IEnumerator SkillAfterTime2()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameManager.insantce.Player;
        if (player != null)
        {
            BulletExplosionAtk bullet = player.GetComponent<BulletExplosionAtk>();
            bullet.enabled = true;
        }
    }
    public void Resume()
    {
        newSkill.SetActive(false);
        Time.timeScale = 1;
    }
}
