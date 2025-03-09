using UnityEngine;

public class BuildingSetup : MonoBehaviour
{
    [SerializeField] private Building _turret;
    [SerializeField] private TurretProjectile _turretProjectile;

    [SerializeField] private Building _miner;
    [SerializeField] private MiningState _miningState;

    [SerializeField] private JSONController _jsonController;

    private void Awake()
    {
        SetupMiner();
        SetupTurret();
    }

    private void SetupTurret()
    {
        _turret.MaxHealth = 5 + _jsonController.PlayerStats.TurretLevel;
        _turretProjectile.Damage = 2 + _jsonController.PlayerStats.TurretLevel;
    }

    private void SetupMiner()
    {
        _miner.MaxHealth = 10 + _jsonController.PlayerStats.MinerLevel;
        _miningState.MiningSpeed = 1 + (_jsonController.PlayerStats.MinerLevel / 2);
    }
}
