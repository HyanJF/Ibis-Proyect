using UnityEngine;

public static class ProductQualityRules
{
    public static QualityType GetRandomQuality(BodyType type)
    {
        float rand = Random.value;

        switch (type)
        {
            case BodyType.Homeless:
                if (rand < 0.6f) return QualityType.Commercial;
                if (rand < 0.85f) return QualityType.Standard;
                return QualityType.Select;

            case BodyType.Peasants:
                if (rand < 0.4f) return QualityType.Commercial;
                if (rand < 0.75f) return QualityType.Standard;
                if (rand < 0.9f) return QualityType.Select;
                return QualityType.Choice;

            case BodyType.Shepherds:
                if (rand < 0.3f) return QualityType.Standard;
                if (rand < 0.65f) return QualityType.Select;
                if (rand < 0.9f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Clergy:
                if (rand < 0.25f) return QualityType.Standard;
                if (rand < 0.55f) return QualityType.Select;
                if (rand < 0.85f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Knights:
                if (rand < 0.2f) return QualityType.Select;
                if (rand < 0.6f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Lineage:
                if (rand < 0.1f) return QualityType.Select;
                if (rand < 0.5f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Princess:
                if (rand < 0.25f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Kings:
                return QualityType.Prime;

            default:
                return QualityType.Standard;
        }
    }

    public static float GetPriceModifier(BodyType type, QualityType quality)
    {
        // Bonos ajustados según el tipo de cuerpo
        switch (quality)
        {
            case QualityType.Prime: return type == BodyType.Kings ? 1.5f : 1.25f;
            case QualityType.Choice: return type == BodyType.Princess ? 1.3f : 1.15f;
            case QualityType.Select: return 1.1f;
            case QualityType.Standard: return 1.05f;
            case QualityType.Commercial: return 1f;
            default: return 1f;
        }
    }
}
