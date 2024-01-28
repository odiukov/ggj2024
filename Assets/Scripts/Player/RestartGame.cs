namespace Player
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class RestartGame : MonoBehaviour
    {
        private void OnMouseDown()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}