using UnityEngine;

public class FireShell : MonoBehaviour {

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;

    [SerializeField] private float shootCd = 0.1f;
    private float _time = 1f;
    void Update() {
        if (_time > shootCd)
        {
            CreateBullet();
            _time = 0f;
        }
        _time += Time.deltaTime;
    }
    void CreateBullet() {

        GameObject currentBullet = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        currentBullet.GetComponent<Parabole>().SetTargetAndStartFlying(enemy.transform.position);
    }
    
}

