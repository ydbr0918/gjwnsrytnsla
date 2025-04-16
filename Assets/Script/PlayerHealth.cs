using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxLife = 3;
    public int CurrentLife = 0;

    public float invincibleTime = 1.0f;
    public bool isInvincible = false;

    private void Start()
    {
        CurrentLife = MaxLife;
    }

    private void Update()
    {
        PlayerDath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            CurrentLife--;
            Destroy(other.gameObject);
            Debug.Log($"ü����:{CurrentLife} ���ҽ��ϴ�.");
        }
    }

    private void PlayerDath()
    {
        

        if (CurrentLife <=0)
        {
            GameOver();
            Debug.Log("GameOver");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name)
;    }
}
