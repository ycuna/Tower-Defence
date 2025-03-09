using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _buildingSize;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarImage;
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    public int CurrentHealth { get; private set; }

    public Vector2 BuildingSize { get => _buildingSize; set {; } }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        _healthBar.SetActive(false);
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
        if (CurrentHealth == _maxHealth)
            _healthBar.SetActive(true);

        CurrentHealth -= damage;
        _healthBarImage.fillAmount = (float)CurrentHealth / (float)_maxHealth;
        if (CurrentHealth < 1)
            DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        Destroy(this.gameObject);
    }

}
