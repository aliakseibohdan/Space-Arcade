using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int heartCount = 3;
    public float shotDelay;
    public float tilt; 
    public float xMin, xMax, zMin, zMax;
    public float speed;
    float nextShotTime; 
    [SerializeField]
    private AudioClip healthPickUp;
    [SerializeField]
    private AudioSource source;
    public GameObject lazerShot;
    public Transform[] lazerGuns;
    public Image[] heartsForegrounds;
    public Image[] heartsBackgrounds;
    private GameManager gameManager;
    private Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();  // получить компонент твердого тела и положить в player
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetLives();
    }

    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal"); // возвращает -1 ... 1 поворот влево/вправо
        var moveVertical = Input.GetAxis("Vertical"); // возвращает -1 ... 1 поворот вверх/вниз

        player.velocity = new Vector3(moveHorizontal, 5, moveVertical) * speed; // скорость 

        var clampedX = Mathf.Clamp(player.position.x, xMin, xMax);
        // клешни, условие для переменной, не выходи за определенные границы
        var clampedZ = Mathf.Clamp(player.position.z, zMin, zMax);

        player.position = new Vector3(clampedX, 0, clampedZ); // создаем границы 

        player.rotation =
            Quaternion.Euler(player.velocity.z * tilt, 0, -player.velocity.x * tilt); // поворот корабля

        if (Time.time > nextShotTime && Input.GetButton("Fire1") && !gameManager.pauseScreen.activeSelf)
        {
            foreach (Transform lazerGun in lazerGuns) 
            {
                Instantiate(lazerShot, lazerGun.position, Quaternion.identity/*летит прямо*/);
                nextShotTime = Time.time + shotDelay;
            }
        }
    }

    public void SetLives()
    {
        for (int i = 0; i < heartCount; i++)
        {
            heartsForegrounds[i].gameObject.SetActive(true);
            heartsBackgrounds[i].gameObject.SetActive(true);
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        gameManager.UpdateGameOverScores();
        Cursor.lockState = CursorLockMode.Confined;
    }

    int index;
    public void OnHit()
    {
        heartCount--;
        heartsForegrounds[index].gameObject.SetActive(false);
        index++;
        if (heartCount == 0) OnDeath();
    }
    public void GetBonus()
    {
        source.PlayOneShot(healthPickUp);
        if (heartCount >= 3) return;
        index--;
        heartCount++;
        heartsForegrounds[index].gameObject.SetActive(true);
    }
    public void GetRocket()
    {

    }
}
