using System.Text;
using Microsoft.CodeAnalysis;

namespace UnrealSharp.ExtensionSourceGenerators;

public class LocalPlayerSubsystemExtensionGenerator : ExtensionGenerator
{
    public override void Generate(ref StringBuilder builder, INamedTypeSymbol classSymbol)
    {
        GenerateGetMethod(ref builder, classSymbol);
    }
    
    private void GenerateGetMethod(ref StringBuilder stringBuilder, INamedTypeSymbol classSymbol)
    {
        string fullTypeName = classSymbol.ToDisplayString();
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("    /// <summary>");
        stringBuilder.AppendLine("    /// Gets the Local Player Subsystem of the specified type.");
        stringBuilder.AppendLine("    /// </summary>");
        stringBuilder.AppendLine("    /// <param name=\"playerController\">The player controller to get the subsystem from.</param>");
        stringBuilder.AppendLine("    /// <returns> The local player subsystem of the specified type. </returns>");
        stringBuilder.AppendLine($"    public static {fullTypeName} Get(APlayerController? playerController = null)");
        stringBuilder.AppendLine("    {");
        stringBuilder.AppendLine("        if (playerController != null)");
        stringBuilder.AppendLine("        {");
        stringBuilder.AppendLine("            return GetLocalPlayerSubsystem<UCLCheatPlayerSubsystem>(playerController);");
        stringBuilder.AppendLine("        }");
        stringBuilder.AppendLine("        return GetLocalPlayerSubsystem<UCLCheatPlayerSubsystem>(UGameplayStatics.GetPlayerController(0));");
        stringBuilder.AppendLine("    }");
    }
}