using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject DestroyVFX;
    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gameSceneManager.Reload();
        Instantiate(DestroyVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
