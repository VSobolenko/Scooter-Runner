using UnityEngine;

namespace Assets.Scripts.Game.Spauner
{
    class SpawnerDecoration : SpawnerObject
    {
        [Header("-4.125")]
        public int frequency = 17;

        private void Start()
        {
            //startSp = startSpawn;
            //startSp.z += 5;
            SpawnBlock();
        }

        private void Update()
        {
            StartUpdate(frequency);
        }
    }
}
