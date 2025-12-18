using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DestroyVFX;
    [SerializeField] int Hitpoints = 10;
    [SerializeField] int ScoreValue = 20;

    private ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();

        if (scoreBoard == null)
        {
            Debug.LogError("⚠️ ScoreBoard not found in scene!");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        Hitpoints--;
        if (Hitpoints <= 0)
        {
            if (scoreBoard != null)
            {
                scoreBoard.InsreaseScore(ScoreValue);
            }
            else
            {
                Debug.LogError("⚠️ Cannot increase score — ScoreBoard is missing!");
            }

            Instantiate(DestroyVFX, transform.position + new Vector3(0f, 3f, 0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
