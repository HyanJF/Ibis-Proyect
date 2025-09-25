using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TestsMorgue : MonoBehaviour
{
    public MorgueManager mManager;

    [Header("UI")]
    public TextMeshProUGUI outputTMP;

    public void GenerateAndDisplayBody()
    {
        // Limpiar
        if (outputTMP != null)
            outputTMP.text = "";

        // Generar cuerpo
        BodySO body = mManager.GenerateBody();

        string log = $"Cuerpo generado: {body.bodyType}\nProductos:\n";

        // HashSet para verificar duplicados
        HashSet<string> uniqueProducts = new HashSet<string>();

        foreach (var product in body.products)
        {
            string line = $"- {product.baseSO.productName} ({product.baseSO.productType})";

            // Calidad
            if (product.hasQuality && product.quality.HasValue)
            {
                line += $" | Calidad: {product.quality} | Precio: {product.GetFinalPrice()}";
            }
            else
            {
                // Cantidades según tipo
                switch (product.baseSO.productType)
                {
                    case ProductType.Fluids:
                        line += $" | Cantidad: {product.amountLiters:F2} L | Precio base por litro: {product.baseSO.basePrice}";
                        break;
                    case ProductType.MeatGeneral:
                        line += $" | Cantidad: {product.amountKg:F2} Kg | Precio base por kg: {product.baseSO.basePrice}";
                        break;
                    case ProductType.Guts:
                        line += $" | Cantidad: {product.amountMeters:F2} m | Precio base por metro: {product.baseSO.basePrice}";
                        break;
                    case ProductType.Parts:
                        line += $" | Cantidad: {product.amountUnits} unidades | Precio por unidad: {product.baseSO.basePrice}";
                        break;
                    case ProductType.Organs:
                    case ProductType.Limbs:
                        line += $" | Precio base: {product.baseSO.basePrice}";
                        break;
                    default:
                        line += $" | Precio: {product.baseSO.basePrice}";
                        break;
                }
            }

            // --- Comprobar duplicados ---
            if (uniqueProducts.Contains(product.baseSO.productName))
            {
                Debug.LogWarning($"Duplicado detectado en este cuerpo: {product.baseSO.productName}");
            }
            else
            {
                uniqueProducts.Add(product.baseSO.productName);
            }

            log += line + "\n";
        }

        // Mostrar en consola y TMP
        Debug.Log(log);
        if (outputTMP != null)
            outputTMP.text = log;
    }

    private void Start()
    {
        GenerateAndDisplayBody();
    }
}
