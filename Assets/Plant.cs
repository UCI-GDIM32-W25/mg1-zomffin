using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant : MonoBehaviour
{
    [SerializeField] SpriteRenderer _plantSprite;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float _timeGrow; 

    private int _count = 0;
    private float _timer = 0;
    private bool _isReady = false; 



    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeGrow)
        {
            growPlant(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player") && _isReady) {
            collision.GetComponent<Player>().CollectPlant();
            Destroy(this.gameObject); 
         }
    }

    private void growPlant()
    {
        if (_count < sprites.Length) {
            _plantSprite.sprite = sprites[_count];
            _count++;
            _timer = 0; 
        } else
        {
            _isReady = true; 
        }
    }
}
