using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private int _lifes = LifeData.Lifes;

    [SerializeField] private TextMeshProUGUI _heartText;
    [SerializeField] private Animator _AnimPanel;

    private void Update()
    {   
        _lifes = LifeData.Lifes;

        _heartText.text = "" + _lifes;

        if (_lifes == 0)
        {
            _AnimPanel.SetBool("IsGameOver", true);
            Invoke("GameOver", 4f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Menu");
        LifeData.Lifes = 3;
    }
}
