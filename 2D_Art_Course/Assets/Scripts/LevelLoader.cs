using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public string scene;

    public void LoadLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
