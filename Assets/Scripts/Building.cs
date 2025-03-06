using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _buildingSize;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private int _maxHealth;

    public int CurrentHealth { get; private set; }

    public Vector2 BuildingSize { get => _buildingSize; set {; } }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void SetColor(bool isAvailableToBuild)
    {
        if (isAvailableToBuild)
            _renderer.material.color = Color.green;
        else
            _renderer.material.color = Color.red;
    }

    public void ResetColor()
    {
        _renderer.material.color = Color.white;
    }

    public void ReceiveDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 1)
            DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        Destroy(this.gameObject);
    }

}
