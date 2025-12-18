using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<Musicplayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
