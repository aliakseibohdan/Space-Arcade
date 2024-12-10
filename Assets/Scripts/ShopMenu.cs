using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public ShipData[] shipsData;
    public Transform shipHolder;
    private int currentShipIndex = 0;
    private GameObject currentShip;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI gunsInstalledText;
    public TextMeshProUGUI livesText;
    public GameManager gameManager;
    public AudioClip buyAccept;
    public AudioClip buyReject;
    public AudioClip selectAccept;
    public AudioClip selectReject;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        score = PlayerPrefs.GetInt("highestScore", score);
        UpdateScore();
        ShowShip(currentShipIndex);
    }

    public void ClickRight()
    {
        currentShipIndex++;
        if (currentShipIndex > shipsData.Length - 1)
            currentShipIndex = 0;
        ShowShip(currentShipIndex);
    }

    public void ClickLeft() 
    {
        currentShipIndex--;
        if (currentShipIndex < 0)
            currentShipIndex = shipsData.Length - 1;
        ShowShip(currentShipIndex);
    }

    public void BuyShip()
    {
        var shipToBuy = shipsData[currentShipIndex];
        if (score >= shipToBuy.price && !shipToBuy.isBought)
        {
            score -= shipsData[currentShipIndex].price;
            UpdateScore();
            shipsData[currentShipIndex].isBought = true;
            source.PlayOneShot(buyAccept);
        }
        else
        {
            source.PlayOneShot(buyReject);
        }
    }

    public void SelectShip()
    {
        var shipToSelect = shipsData[currentShipIndex];
        if (shipToSelect.isBought)
        {
            PlayerPrefs.SetInt("shipIndex", currentShipIndex);
            source.PlayOneShot(selectAccept);
        }
        else
        {
            source.PlayOneShot(selectReject);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("highestScore", score);
    }

    void ShowShip (int index)
    {
        if (currentShip != null)
            Destroy(currentShip);

        nameText.text = shipsData[index].name;
        speedText.text = "Speed: " + shipsData[index].speed.ToString();
        gunsInstalledText.text = "Guns: " + shipsData[index].gunsInstalled.ToString();
        livesText.text = "Lives: " + shipsData[index].lives.ToString();
        priceText.text = "Price: " + shipsData[index].price.ToString();

        currentShip = Instantiate(shipsData[index].ship, shipHolder.position, shipHolder.rotation);
        currentShip.GetComponent<PlayerScript>().enabled = false;
        currentShip.GetComponent<Rigidbody>().isKinematic = true;
        currentShip.GetComponent<BoxCollider>().enabled = false;
    }
}
