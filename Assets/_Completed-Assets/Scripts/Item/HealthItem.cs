using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
    public class HealthItem : MonoBehaviour
    {
        public void Start() {
            Invoke(nameof(getNewPosition), 5f);

        }
        public void OnTriggerEnter(Collider other) {
            TankHealth tankHealth = other.GetComponent<TankHealth>();

            if (tankHealth != null) {
                tankHealth.IncreaseHealth(100f);
                getNewPosition();
            }
        }

        private void getNewPosition() {
            var x = Random.Range(-20, 20);
            var y = transform.position.y;
            var z = Random.Range(-20, 20);
            var pos = new Vector3(x, y, z);
            transform.position = pos;
        }
    }
}

