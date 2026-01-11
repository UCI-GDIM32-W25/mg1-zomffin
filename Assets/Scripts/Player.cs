using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private float _horizontal;
    private float _vertical;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0; 
        
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        _horizontal = Mathf.Round(Input.GetAxis("Horizontal"));
        _vertical = Mathf.Round(Input.GetAxis("Vertical")); 

        _playerTransform.position = _playerTransform.position + new Vector3(_horizontal * _speed * Time.deltaTime, _vertical * _speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }

    }

    public void PlantSeed ()
    {
        if (_numSeedsLeft > 0)
        {
            GameObject newPlant = Instantiate(_plantPrefab);
            newPlant.transform.position = _playerTransform.position; 
            _numSeedsLeft--;
            _numSeedsPlanted++; 
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }
}
