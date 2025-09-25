using System.Collections.Generic;
using UnityEngine;

public static class ProductRules
{
    // --- Dependencias biológicas ---
    public static Dictionary<string, List<string>> Dependencies = new Dictionary<string, List<string>>()
    {
        { "Head", new List<string> { "Eye", "Ear", "Teeth", "Tongue", "Nose", "Brain" } },
        { "HandOrFoot", new List<string> { "Finger" } },
        { "Stomach", new List<string> { "GastricJuice", "Esophagus" } }, // Esophagus depende de Stomach o Head
        { "Liver", new List<string> { "Bile", "Gallbladder" } }, // Gallbladder depende de Liver
        { "Kidney", new List<string> { "Urine" } },
        { "Guts", new List<string> { "Appendix" } }, // Apéndice depende de tripas (Guts)
        { "Eye", new List<string> { "Tears" } }, // Lágrimas dependen de ojos
        { "Tongue", new List<string> { "Saliva" } }, // Saliva depende de lengua
        { "Ear", new List<string> { "Earwax" } } // Cera depende de orejas
    };

    // Verifica si un producto puede generarse según dependencias
    public static bool IsDependencySatisfied(string product, HashSet<string> generatedProducts)
    {
        // Caso especial: dedos requieren mano o pie
        if (product == "Finger")
            return generatedProducts.Contains("Hand") || generatedProducts.Contains("Foot");

        foreach (var kvp in Dependencies)
        {
            if (kvp.Value.Contains(product))
            {
                return generatedProducts.Contains(kvp.Key);
            }
        }

        return true; // Por defecto, no requiere nada
    }

    // ---------------- Órganos ----------------
    public static int GetOrganAmount(string name)
    {
        switch (name)
        {
            case "Brain": return Random.Range(1, 2);
            case "Eye": return Random.Range(1, 3);
            case "Heart": return Random.Range(1, 2);
            case "Lung": return Random.Range(1, 3);
            case "Liver": return Random.Range(1, 2);
            case "Kidney": return Random.Range(1, 3);
            case "Stomach": return Random.Range(1, 2);
            case "Pancreas": return Random.Range(1, 2);
            case "Spleen": return Random.Range(1, 2);
            case "Ear": return Random.Range(1, 3);
            case "Nose": return Random.Range(1, 2);
            case "Tongue": return Random.Range(1, 2);
            case "Esophagus": return Random.Range(1, 2);
            case "Gallbladder": return Random.Range(1, 2);
            case "Appendix": return Random.Range(1, 2);
            default: return 0;
        }
    }

    // ---------------- Extremidades ----------------
    public static int GetLimbAmount(string name)
    {
        switch (name)
        {
            case "Arm": return Random.Range(1, 3);
            case "Leg": return Random.Range(1, 3);
            case "Hand": return Random.Range(1, 3);
            case "Foot": return Random.Range(1, 3);
            case "Head": return Random.Range(1, 2);
            default: return 1;
        }
    }

    // ---------------- Fluids ----------------
    public static float GetFluidAmount(string name)
    {
        switch (name)
        {
            case "Blood": return Random.Range(3f, 6f);
            case "Bile": return Random.Range(0.2f, 0.8f);
            case "GastricJuice": return Random.Range(0.5f, 1.5f);
            case "Lymph": return Random.Range(1f, 2f);
            case "Sweat": return Random.Range(0.1f, 0.5f);
            case "Urine": return Random.Range(0.3f, 1f);
            case "Mucus": return Random.Range(0.05f, 0.3f);
            case "Plasma": return Random.Range(1f, 2f);
            case "WaterBody": return Random.Range(20f, 30f);
            default: return 0f;
        }
    }

    // ---------------- Meat / General ----------------
    public static float GetMeatAmount(string name)
    {
        switch (name)
        {
            case "Skin": return Random.Range(10f, 30f);
            case "BodyFat": return Random.Range(5f, 15f);
            case "MeatGeneral": return Random.Range(10f, 30f);
            default: return 1f;
        }
    }

    // ---------------- Guts ----------------
    public static float GetGutsAmount(string name)
    {
        switch (name)
        {
            case "Guts": return Random.Range(5.5f, 7f); // En metros
            default: return 1f;
        }
    }

    // ---------------- Parts ----------------
    public static int GetPartsAmount(string name)
    {
        switch (name)
        {
            case "Finger": return Random.Range(1, 21);
            case "Teeth": return Random.Range(1, 33);
            case "Tears": return Random.Range(1, 6);
            case "Saliva": return Random.Range(2, 8);
            case "Earwax": return Random.Range(3, 7);
            default: return 1;
        }
    }
}
