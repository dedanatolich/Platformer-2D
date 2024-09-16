using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int _diamonds = 0;

    [SerializeField] private AudioSource _audioSelection;
    [SerializeField] private TextMeshProUGUI _diamondsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            _audioSelection.Play();
            Destroy(collision.gameObject);
            _diamonds++;
            _diamondsText.text = "" + _diamonds;
        }
    }
}
