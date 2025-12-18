using UnityEngine;
using UnityEngine.Video;

public class cursor : MonoBehaviour
{
   
     private void OnEnable() {
        
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
}
}