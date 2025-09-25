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
    public int minShepherds = 5, maxShepherds = 9;
    public int minClergy = 7, maxClergy = 11;
    public int minKnights = 10, maxKnights = 13;
    public int minLineage = 11, maxLineage = 16;
    public int minPrincess = 12 , maxPrincess = 18;
    public int minKing = 15, maxKing = 25;

    public BodySO GenerateBody()
    {
        // Elegir tipo de cuerpo
        BodyType type = GetRandomBodyType();
        BodySO newBody = new BodySO(type);

        // Cantidad de productos a generar
        int productCount = GetProductCount(type);
        Debug.Log("Productos generados: " + productCount);

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
        if (rand < 0.005f) return BodyType.Kings;
        if (rand < 0.015f) return BodyType.Princess;
        if (rand < 0.07f) return BodyType.Lineage;
        if (rand < 0.15f) return BodyType.Knights;
        if (rand < 0.25f) return BodyType.Clergy;
        if (rand < 0.40f) return BodyType.Shepherds;
        if (rand < 0.50f) return BodyType.Peasants;
        return BodyType.Homeless;
    }

    private int GetProductCount(BodyType type)
    {
        switch (type)
        {
            case BodyType.Homeless: return Random.Range(minHomeless, maxHomeless + 1);
            case BodyType.Peasants: return Random.Range(minPeasants, maxPeasants + 1);
            case BodyType.Shepherds: return Random.Range(minShepherds, maxShepherds + 1);
            case BodyType.Clergy: return Random.Range(minClergy, maxClergy + 1);
            case BodyType.Knights: return Random.Range(minKnights, maxKnights + 1);
            case BodyType.Lineage: return Random.Range(minLineage, maxLineage + 1);
            case BodyType.Princess: return Random.Range(minPrincess, maxPrincess + 1);
            case BodyType.Kings: return Random.Range(minKing, maxKing + 1);
            default: return 0;
        }
    }
}
