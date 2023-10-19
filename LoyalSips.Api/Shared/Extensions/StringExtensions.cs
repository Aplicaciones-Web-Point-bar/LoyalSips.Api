namespace LoyalSips.API.Shared.Extensions;

public static class StringExtensions
{
    //covierte una cadena text o de string a una cadena en notación snake_case osea minuscula separado por _
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<char> Convert(CharEnumerator e) //recorre los caracteres de la cadena 
        {
            if (!e.MoveNext()) yield break;
            yield return char.ToLower(e.Current);
            while (e.MoveNext())
            {
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
        return new string(Convert(text.GetEnumerator()).ToArray());
    }
}