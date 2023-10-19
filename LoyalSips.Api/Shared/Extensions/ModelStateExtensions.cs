using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningCenter2.API.Shared.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this
        ModelStateDictionary dictionary) //representar el estado del modelo y las validaciones
    // dauna solicitud HTTP
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}