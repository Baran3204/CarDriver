using System.Data;
using NUnit.Framework.Internal;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _stone;


    private void Update() 
    {
        SpawnStone();    
    }

    



























    private void SpawnStone()
    {
      int rnd = Random.Range(1, 5);
      switch (rnd)
      {
        case 2:
        int rnd2 = Random.Range(1, 5);
            switch(rnd2)
            {
                case 2:
                     int rnd3 = Random.Range(1, 5);
                     switch (rnd3)
                     {
                        case 2:
                            int rnd4 = Random.Range(1, 5);
                            switch (rnd4)
                            {
                                case 2:
                                int rnd5 = Random.Range(1, 5);
                                switch(rnd5)
                                {
                                    case 2:
                                        Instantiate(_stone, transform.position, Quaternion.identity);
                                        break;
                                }
                                break;
                            }
                           break;
                     }
                break;
            } 
        break;
      }  
      
    }
}
