

using Lib.Main.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Lib.Main.Helpers;

public static class ContactJsonSerializer
{
    public static List<ContactEntity> Deserialize(string content)
    {
        try
        {
            return JsonSerializer.Deserialize<List<ContactEntity>>(content) ?? null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("You got errors in json deserialize: " + ex.Message);
            return null!;
        }
    }

    public static string Serialize(List<ContactEntity> list)
    {
        try
        {
            return JsonSerializer.Serialize(list);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("You got errors in json serialize: " + ex.Message);
            return null!;
        }
    }
}
