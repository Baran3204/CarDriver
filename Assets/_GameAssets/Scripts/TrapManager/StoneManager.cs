using System.Data;
using NUnit.Framework.Internal;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _stone;
    private float _stoneSpawnChance = 0.1f;

    private void Update() 
    {
        SpawnStone();    
    }

    private void SpawnStone()
    {
     GameObject CurrentObject = _stone;
      float rnd = Random.Range(0f, 75f);
      if(_stoneSpawnChance >= rnd) { CurrentObject = Instantiate(_stone, transform.position, Quaternion.identity);}

      if(CurrentObject == _stone) { return; }
      else Destroy(CurrentObject, 3f); 
      
    }
}
