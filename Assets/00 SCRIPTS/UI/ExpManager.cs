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
    protected int level = 1;
    public int Level => level;
    [SerializeField] protected Image fillExp;
    [SerializeField] protected GameObject newSkill;
    

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
        if(level == 3)
        {
            //
        }
    }


    protected IEnumerator LevelUpAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        newSkill.SetActive(true);
        Time.timeScale = 0;
        GameObject player = GameManager.insantce.Player;
        if (player != null)
        {
            NormalAtk normal = player.GetComponent<NormalAtk>();
            normal.enabled = true;
        }
    }
    public void Resume()
    {
        newSkill.SetActive(false);
        Time.timeScale = 1;
    }
}
