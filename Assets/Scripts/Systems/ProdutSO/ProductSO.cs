using UnityEngine;

[System.Serializable]
public class Product
{
    public ProductBaseSO baseSO;
    public bool hasQuality;
    public QualityType? quality;
    public float priceModifier;

    // Cantidades especiales (solo para almacenamiento)
    public float amountLiters;   // Fluids
    public float amountKg;       // MeatGeneral
    public float amountMeters;   // Guts
    public int amountUnits;      // Parts

    public Product(ProductBaseSO baseSO, bool hasQuality, QualityType? quality, float priceModifier)
    {
        this.baseSO = baseSO;
        this.hasQuality = hasQuality;
        this.quality = quality;
        this.priceModifier = priceModifier;

        this.amountLiters = 0f;
        this.amountKg = 0f;
        this.amountMeters = 0f;
        this.amountUnits = 0;
    }

    /// <summary>
    /// Solo los órganos y extremidades tienen precio afectado por calidad.
    /// Los demás mantienen su basePrice (ya que se fraccionarán en otra fase).
    /// </summary>
    public int GetFinalPrice()
    {
        switch (baseSO.productType)
        {
            case ProductType.Organs:
            case ProductType.Limbs:
                if (hasQuality && quality.HasValue)
                    return Mathf.RoundToInt(baseSO.basePrice * priceModifier);
                else
                    return baseSO.basePrice;

            default:
                // Fluidos, meat, guts y parts NO se calculan aquí.
                // Su precio depende del sistema de almacenamiento/venta.
                return baseSO.basePrice;
        }
    }
}
