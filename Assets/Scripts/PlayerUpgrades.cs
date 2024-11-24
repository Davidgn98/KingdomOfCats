using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrades : MonoBehaviour
{
    private string[] upgrades = new string[7];
    public GameObject upgradesMenu;
    public Button[] upgradeButtons;
    public TMP_Text[] buttonTexts;
    public PlayerMovement playerMovement;
    public PlayerDamage playerDamage;
    public BulletManager bulletManager;
    public BulletMovement bulletMovement;
    public KingManager kingManager;
    private AudioSource audioSource;
    public AudioClip upgradeSound;
    public AudioClip upgradeButton;
    // Start is called before the first frame update
    void Start()
    {
        upgrades[0] = "Speed Up";
        upgrades[1] = "Heal King";
        upgrades[2] = "Heal";
        upgrades[3] = "Fire Rate Up";
        upgrades[4] = "Add Shot";
        upgrades[5] = "Range Up";
        upgrades[6] = "Bullet Speed Up";
        audioSource = GetComponent<AudioSource>();
    }

    public void newUpgrade()
    {
        if (audioSource != null && upgradeSound != null)
        {
            audioSource.PlayOneShot(upgradeSound);
        }
        Time.timeScale = 0;
        upgradesMenu.SetActive(true);
        int randomIndex1 = Random.Range(0, upgrades.Length);
        int randomIndex2;
        int randomIndex3;
        do
        {
            randomIndex2 = Random.Range(0, upgrades.Length);
        } while (randomIndex1 == randomIndex2);
        do
        {
            randomIndex3 = Random.Range(0, upgrades.Length);
        } while (randomIndex3 == randomIndex1 || randomIndex3 == randomIndex2);

        buttonTexts[0].text = upgrades[randomIndex1];
        buttonTexts[1].text = upgrades[randomIndex2];
        buttonTexts[2].text = upgrades[randomIndex3];

        upgradeButtons[0].onClick.RemoveAllListeners();
        upgradeButtons[1].onClick.RemoveAllListeners();
        upgradeButtons[2].onClick.RemoveAllListeners();

        AssignUpgradeListener(upgradeButtons[0], upgrades[randomIndex1]);
        AssignUpgradeListener(upgradeButtons[1], upgrades[randomIndex2]);
        AssignUpgradeListener(upgradeButtons[2], upgrades[randomIndex3]);
    }
    private void AssignUpgradeListener(Button button, string upgrade)
    {
        switch (upgrade)
        {
            case "Speed Up":
                button.onClick.AddListener(ApplySpeedUpgrade);
                break;
            case "Heal":
                button.onClick.AddListener(ApplyHeal);
                break;
            case "Add Shot":
                button.onClick.AddListener(ApplyAddShot);
                break;
            case "Heal King":
                button.onClick.AddListener(ApplyHealKing);
                break;
            case "Fire Rate Up":
                button.onClick.AddListener(ApplyFireRateUpgrade);
                break;
            case "Range Up":
                button.onClick.AddListener(ApplyRangeUpgrade);
                break;
            case "Bullet Speed Up":
                button.onClick.AddListener(ApplyBulletSpeedUpgrade);
                break;
            default:
                break;
        }
        button.onClick.AddListener(PlayUpgradeSound);
        button.onClick.AddListener(resumeGame);
    }
    public void resumeGame()
    {
        upgradesMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayUpgradeSound()
    {
        if (audioSource != null && upgradeButton != null)
        {
            audioSource.PlayOneShot(upgradeButton);
        }
    }

    public void ApplySpeedUpgrade()
    {
        if (playerMovement != null)
        {
            playerMovement.speed += 1.2f;
        }
    }

    public void ApplyHeal()
    {
        if (playerDamage != null && playerDamage.vida < 3)
        {
            playerDamage.vida += 1;
        }
    }

    public void ApplyAddShot()
    {
        if (bulletManager != null)
        {
            bulletManager.additionalShots += 1;
        }
    }

    public void ApplyHealKing()
    {
        if (playerMovement != null && playerDamage.vida < 10)
        {
            kingManager.vida = Mathf.Min(kingManager.vida + 2, 10);
            kingManager.barraVida.fillAmount = kingManager.vida / 10f;
        }
    }
    public void ApplyFireRateUpgrade()
    {
        if (bulletManager != null)
        {
            bulletManager.fireRate -= 0.05f;
        }
    }
    public void ApplyRangeUpgrade()
    {
        if (bulletMovement != null)
        {
            bulletMovement.range += 0.5f;
        }
    }
    public void ApplyBulletSpeedUpgrade()
    {
        if (playerMovement != null)
        {
            bulletMovement.bulletSpeed += 0.6f;
        }
    }
}
