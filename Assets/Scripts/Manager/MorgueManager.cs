using System.Collections.Generic;
using UnityEngine;

// Script principal que genera los cuerpos y asigna productos
public class MorgueManager : MonoBehaviour
{
    [Header("Base de Productos")]
    public List<ProductBaseSO> extremidadesBase;
    public List<ProductBaseSO> organosBase;
    public List<ProductBaseSO> fluidsBase;
    public List<ProductBaseSO> meatBase;
    public List<ProductBaseSO> gutsBase;
    public List<ProductBaseSO> partsBase;

    [Header("MinimosYMaximosBodyProductCount")]
    public int minHomeless = 2, maxHomeless = 5;
    public int minPeasants = 3, maxPeasants = 7;
    public int minArtisans = 4, maxArtisans = 8;
    public int minMerchants = 5, maxMerchants = 9;
    public int minSquires = 6, maxSquires = 10;
    public int minShepherds = 5, maxShepherds = 9;
    public int minClergy = 7, maxClergy = 11;
    public int minKnights = 10, maxKnights = 13;
    public int minLineage = 11, maxLineage = 16;
    public int minHeirs = 12, maxHeirs = 18;
    public int minCrown = 15, maxCrown = 25;
    public int minEmperor = 20, maxEmperor = 30;

    [Header("Limite global de productos por cuerpo")]
    public int maxProductsPerBody = 20;

    public BodySO GenerateBody()
    {
        // Elegir tipo de cuerpo
        BodyType type = GetRandomBodyType();
        BodySO newBody = new BodySO(type);

        // Cantidad de productos a generar
        int productCount = GetProductCount(type);
        Debug.Log("Productos generados: " + productCount + " para " + type);

        // Crear generator y pasar listas de productos + bodyType
        BodyGenerator generator = new BodyGenerator(
            organs: organosBase,
            limbs: extremidadesBase,
            fluids: fluidsBase,
            meat: meatBase,
            guts: gutsBase,
            parts: partsBase,
            bodyType: type
        );

        newBody.products = generator.GenerateProducts(productCount);

        return newBody;
    }

    private BodyType GetRandomBodyType()
    {
        float rand = Random.value;
        if (rand < 0.002f) return BodyType.Emperor;           // 0.2%
        if (rand < 0.01f) return BodyType.Crown;             // 0.8%
        if (rand < 0.03f) return BodyType.Heirs;             // 2%
        if (rand < 0.08f) return BodyType.Lineage;           // 5%
        if (rand < 0.15f) return BodyType.Knights;           // 7%
        if (rand < 0.23f) return BodyType.Clergy;            // 8%
        if (rand < 0.30f) return BodyType.Squires;           // 7%
        if (rand < 0.38f) return BodyType.Shepherds;         // 8%
        if (rand < 0.45f) return BodyType.Merchants;         // 7%
        if (rand < 0.53f) return BodyType.Artisans;          // 8%
        if (rand < 0.63f) return BodyType.Peasants;          // 10%
        return BodyType.Homeless;                             // 37%
    }

    private int GetProductCount(BodyType type)
    {
        int count = 0;

        switch (type)
        {
            case BodyType.Homeless: count = Random.Range(minHomeless, maxHomeless + 1); break;
            case BodyType.Peasants: count = Random.Range(minPeasants, maxPeasants + 1); break;
            case BodyType.Artisans: count = Random.Range(minArtisans, maxArtisans + 1); break;
            case BodyType.Merchants: count = Random.Range(minMerchants, maxMerchants + 1); break;
            case BodyType.Squires: count = Random.Range(minSquires, maxSquires + 1); break;
            case BodyType.Shepherds: count = Random.Range(minShepherds, maxShepherds + 1); break;
            case BodyType.Clergy: count = Random.Range(minClergy, maxClergy + 1); break;
            case BodyType.Knights: count = Random.Range(minKnights, maxKnights + 1); break;
            case BodyType.Lineage: count = Random.Range(minLineage, maxLineage + 1); break;
            case BodyType.Heirs: count = Random.Range(minHeirs, maxHeirs + 1); break;
            case BodyType.Crown: count = Random.Range(minCrown, maxCrown + 1); break;
            case BodyType.Emperor: count = Random.Range(minEmperor, maxEmperor + 1); break;
            default: count = 0; break;
        }

        // Limitar a máximo global
        return Mathf.Min(count, maxProductsPerBody);
    }
}
