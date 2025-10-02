using UnityEngine;

public static class ProductQualityRules
{
    public static QualityType GetRandomQuality(BodyType type)
    {
        float rand = Random.value;

        switch (type)
        {
            // 1️⃣ Clases bajas
            case BodyType.Homeless:
                if (rand < 0.6f) return QualityType.Rotten;
                if (rand < 0.9f) return QualityType.Commercial;
                return QualityType.Standard;

            case BodyType.Peasants:
                if (rand < 0.1f) return QualityType.Rotten;
                if (rand < 0.4f) return QualityType.Commercial;
                if (rand < 0.8f) return QualityType.Standard;
                return QualityType.Select;

            case BodyType.Artisans:
                if (rand < 0.05f) return QualityType.Rotten;
                if (rand < 0.3f) return QualityType.Commercial;
                if (rand < 0.7f) return QualityType.Standard;
                if (rand < 0.9f) return QualityType.Select;
                return QualityType.Choice;

            case BodyType.Merchants:
                if (rand < 0.05f) return QualityType.Commercial;
                if (rand < 0.25f) return QualityType.Standard;
                if (rand < 0.6f) return QualityType.Select;
                if (rand < 0.85f) return QualityType.Choice;
                return QualityType.Prime;

            // 2️⃣ Clases medias
            case BodyType.Squires:
                if (rand < 0.1f) return QualityType.Standard;
                if (rand < 0.35f) return QualityType.Select;
                if (rand < 0.65f) return QualityType.Choice;
                if (rand < 0.85f) return QualityType.Prime;
                return QualityType.Supreme;

            case BodyType.Shepherds:
                if (rand < 0.05f) return QualityType.Commercial;
                if (rand < 0.25f) return QualityType.Standard;
                if (rand < 0.55f) return QualityType.Select;
                if (rand < 0.8f) return QualityType.Choice;
                return QualityType.Prime;

            case BodyType.Clergy:
                if (rand < 0.05f) return QualityType.Standard;
                if (rand < 0.25f) return QualityType.Select;
                if (rand < 0.55f) return QualityType.Choice;
                if (rand < 0.8f) return QualityType.Prime;
                return QualityType.Supreme;

            case BodyType.Knights:
                if (rand < 0.1f) return QualityType.Select;
                if (rand < 0.4f) return QualityType.Choice;
                if (rand < 0.7f) return QualityType.Prime;
                if (rand < 0.9f) return QualityType.Supreme;
                return QualityType.Legendary;

            // 3️⃣ Clases altas
            case BodyType.Lineage:
                if (rand < 0.1f) return QualityType.Choice;
                if (rand < 0.5f) return QualityType.Prime;
                if (rand < 0.8f) return QualityType.Supreme;
                return QualityType.Legendary;

            case BodyType.Heirs:
                if (rand < 0.15f) return QualityType.Prime;
                if (rand < 0.5f) return QualityType.Supreme;
                if (rand < 0.8f) return QualityType.Legendary;
                return QualityType.Divine;

            case BodyType.Crown:
                if (rand < 0.2f) return QualityType.Supreme;
                if (rand < 0.6f) return QualityType.Legendary;
                return QualityType.Divine;

            case BodyType.Emperor:
                if (rand < 0.3f) return QualityType.Supreme;
                if (rand < 0.7f) return QualityType.Legendary;
                return QualityType.Divine;

            default:
                return QualityType.Standard;
        }
    }

    public static float GetPriceModifier(BodyType type, QualityType quality)
    {
        switch (quality)
        {
            case QualityType.Choice:
                switch (type)
                {
                    case BodyType.Artisans: return 1.1f;
                    case BodyType.Merchants: return 1.15f;
                    case BodyType.Squires: return 1.2f;
                    default: return 1.05f;
                }

            case QualityType.Prime:
                switch (type)
                {
                    case BodyType.Merchants: return 1.2f;
                    case BodyType.Squires: return 1.25f;
                    case BodyType.Shepherds: return 1.25f;
                    case BodyType.Clergy: return 1.3f;
                    default: return 1.25f;
                }

            case QualityType.Supreme:
                switch (type)
                {
                    case BodyType.Knights: return 1.3f;
                    case BodyType.Clergy: return 1.25f;
                    case BodyType.Lineage: return 1.35f;
                    case BodyType.Heirs: return 1.4f;
                    default: return 1.3f;
                }

            case QualityType.Legendary:
                switch (type)
                {
                    case BodyType.Lineage: return 1.4f;
                    case BodyType.Heirs: return 1.45f;
                    case BodyType.Crown: return 1.5f;
                    case BodyType.Emperor: return 1.6f;
                    default: return 1.5f;
                }

            case QualityType.Divine:
                switch (type)
                {
                    case BodyType.Heirs: return 1.5f;
                    case BodyType.Crown: return 1.6f;
                    case BodyType.Emperor: return 1.7f;
                    default: return 1.5f;
                }

            // Calidades bajas
            case QualityType.Standard: return 1.05f;
            case QualityType.Commercial: return 1f;
            case QualityType.Rotten: return 0.5f;

            default: return 1f;
        }
    }
}
