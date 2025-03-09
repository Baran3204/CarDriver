using UnityEngine;
public class HealTrapManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _heal;
    private float _healSpawnChance = 0.1f;

    private void Update() 
    {
        SpawnHeal();    
    }

    private void SpawnHeal()
    {
        float rnd = Random.Range(0f, 100f);
        GameObject curentObject = _heal;

        if(_healSpawnChance >= rnd) { curentObject = Instantiate(_heal, transform.position, Quaternion.identity); }
        if(curentObject == _heal) { return; }
        Destroy(curentObject, 3f);
    }
}
