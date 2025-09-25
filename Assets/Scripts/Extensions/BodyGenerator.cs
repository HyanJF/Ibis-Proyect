using System.Collections.Generic;
using UnityEngine;

public class BodyGenerator
{
    // Listas de productos por categoria
    private List<ProductBaseSO> organs;
    private List<ProductBaseSO> limbs;
    private List<ProductBaseSO> fluids;
    private List<ProductBaseSO> meat;
    private List<ProductBaseSO> guts;
    private List<ProductBaseSO> parts;

    private BodyType bodyType;

    // Constructor
    public BodyGenerator(
        List<ProductBaseSO> organs,
        List<ProductBaseSO> limbs,
        List<ProductBaseSO> fluids,
        List<ProductBaseSO> meat,
        List<ProductBaseSO> guts,
        List<ProductBaseSO> parts,
        BodyType bodyType)
    {
        this.organs = organs;
        this.limbs = limbs;
        this.fluids = fluids;
        this.meat = meat;
        this.guts = guts;
        this.parts = parts;
        this.bodyType = bodyType; 
    }

    public List<Product> GenerateProducts(int productCount)
    {
        List<Product> result = new List<Product>();
        HashSet<string> chosenProducts = new HashSet<string>();
        int added = 0;

        // Listas de todas las categorías
        List<int> categories = new List<int> { 0, 1, 2, 3, 4, 5 };

        while (added < productCount)
        {
            // Elegir categoría aleatoria
            int typeRoll = categories[Random.Range(0, categories.Count)];
            ProductBaseSO baseSO = null;
            float amount = 0f;

            switch (typeRoll)
            {
                case 0: // Órganos
                    if (organs.Count == 0) continue;
                    baseSO = organs[Random.Range(0, organs.Count)];
                    amount = ProductRules.GetOrganAmount(baseSO.productName);
                    break;
                case 1: // Extremidades
                    if (limbs.Count == 0) continue;
                    baseSO = limbs[Random.Range(0, limbs.Count)];
                    amount = ProductRules.GetLimbAmount(baseSO.productName);
                    break;
                case 2: // Fluids
                    if (fluids.Count == 0) continue;
                    baseSO = fluids[Random.Range(0, fluids.Count)];
                    amount = ProductRules.GetFluidAmount(baseSO.productName);
                    break;
                case 3: // Meat
                    if (meat.Count == 0) continue;
                    baseSO = meat[Random.Range(0, meat.Count)];
                    amount = ProductRules.GetMeatAmount(baseSO.productName);
                    break;
                case 4: // Guts
                    if (guts.Count == 0) continue;
                    baseSO = guts[Random.Range(0, guts.Count)];
                    amount = ProductRules.GetGutsAmount(baseSO.productName);
                    break;
                case 5: // Parts
                    if (parts.Count == 0) continue;
                    baseSO = parts[Random.Range(0, parts.Count)];
                    amount = ProductRules.GetPartsAmount(baseSO.productName);
                    break;
            }

            if (baseSO == null) continue;

            // --- RESTRICCION DE DUPLICADOS ---
            if (chosenProducts.Contains(baseSO.productName))
            {
                // Debug para ver productos descartados
                Debug.Log($"Producto descartado por duplicado: {baseSO.productName}");
                continue;
            }

            // --- RESTRICCION DE DEPENDENCIAS ---
            if (!ProductRules.IsDependencySatisfied(baseSO.productName, chosenProducts))
            {
                Debug.Log($"Dependencia no cumplida: {baseSO.productName} bloqueado.");
                continue;
            }

            chosenProducts.Add(baseSO.productName);

            // --- Crear productos según tipo ---
            if (typeRoll == 0 || typeRoll == 1) // Órganos o Extremidades
            {
                int units = Mathf.RoundToInt(amount);
                for (int i = 0; i < units; i++)
                {
                    Product newProduct = new Product(baseSO, baseSO.hasQuality, null, 1f);

                    if (baseSO.hasQuality)
                    {
                        QualityType quality = ProductQualityRules.GetRandomQuality(bodyType);
                        newProduct.quality = quality;
                        newProduct.priceModifier = ProductQualityRules.GetPriceModifier(bodyType, quality);
                    }

                    result.Add(newProduct);
                    added++;
                }
            }
            else
            {
                // Fluids, Meat, Guts, Parts → mantienen cantidades
                Product newProduct = new Product(baseSO, baseSO.hasQuality, null, 1f);

                switch (typeRoll)
                {
                    case 2: newProduct.amountLiters = amount; break;
                    case 3: newProduct.amountKg = amount; break;
                    case 4: newProduct.amountMeters = amount; break;
                    case 5: newProduct.amountUnits = Mathf.RoundToInt(amount); break;
                }

                if (baseSO.hasQuality)
                {
                    QualityType quality = ProductQualityRules.GetRandomQuality(bodyType);
                    newProduct.quality = quality;
                    newProduct.priceModifier = ProductQualityRules.GetPriceModifier(bodyType, quality);
                }

                result.Add(newProduct);
                added++;
            }
        }
        
        return result;
    }


}
