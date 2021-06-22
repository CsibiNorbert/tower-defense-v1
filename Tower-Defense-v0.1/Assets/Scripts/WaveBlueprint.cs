using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Information about wave
    /// </summary>
    [System.Serializable] // <- This tells unity that this should show on the inspector
    public class WaveBlueprint
    {
        public GameObject enemy;
        public int amountEnemiesToSpawn;
        public float spawnRate;
    }
}
