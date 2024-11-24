using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{
    [SerializeField] int currentEXP, maxEXP, currentLevel;
    [SerializeField] TMP_Text levelText;
    public Image expBar;
    private PlayerUpgrades playerUpgrades;
    private AudioSource audioSource;
    public AudioClip getEXP;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerUpgrades = GetComponent<PlayerUpgrades>();
        UpdateEXPBar();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }

    public void AddEXP(int exp)
    {
        
        currentEXP += exp;
        
        if (currentEXP >= maxEXP)
        {
            currentEXP = 0;
            currentLevel += 1;
            maxEXP = maxEXP + 5;
            playerUpgrades.newUpgrade();
        }
        UpdateEXPBar();
    }

    private void UpdateEXPBar()
    {
        if (audioSource != null && getEXP != null && currentEXP != 0)
        {
            audioSource.PlayOneShot(getEXP);
        }
        float fillAmount = (float)currentEXP / maxEXP;
        expBar.fillAmount = Mathf.Clamp01(fillAmount);
    }
}
