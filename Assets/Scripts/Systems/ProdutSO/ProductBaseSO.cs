using UnityEngine;

[CreateAssetMenu(fileName = "NewProductBase", menuName = "Game/Product Base")]
public class ProductBaseSO : ScriptableObject
{
    [Header("Datos base")]
    public string productName;
    public ProductType productType;
    public Sprite icon;
    public int basePrice;

    [Header("Opciones")]
    public bool hasQuality;
    
}
