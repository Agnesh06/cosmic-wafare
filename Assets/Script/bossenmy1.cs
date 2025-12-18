using UnityEngine;

public class bossenemy : MonoBehaviour
{
    [SerializeField] GameObject DestroyVFX;
    [SerializeField] int Hitpoints = 10;
    [SerializeField] int ScoreValue = 20;

    ScoreBoard scoreBoard;
    bool isDying = false;

    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!isDying) // only process hit if not dying
        {
            Hitpoints--;
            if (Hitpoints <= 0)
            {
                StartCoroutine(ProcessDeath());
            }
        }
    }

    private System.Collections.IEnumerator ProcessDeath()
    {
        isDying = true; // stop future hits
        scoreBoard.InsreaseScore(ScoreValue);

        Instantiate(DestroyVFX, transform.position + new Vector3(0f, 44f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(DestroyVFX, transform.position + new Vector3(0f, 44f, -141f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(DestroyVFX, transform.position + new Vector3(0f, 44f, 64f), Quaternion.identity);

        Destroy(gameObject);
    }
}
