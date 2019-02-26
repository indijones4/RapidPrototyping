using System.Text;
using System;

public static class Utilities
{
    /// <summary>
    /// Get the length of a given enum
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int EnumLength(this Enum value)
    {
        Type t = value.GetType();
        return Enum.GetValues(t).Length - 1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EnumToString(this Enum value)
    {
        var stringVal = value.ToString();
        var bld = new StringBuilder();

        for (var i = 0; i < stringVal.Length; i++)
        {
            if (char.IsUpper(stringVal[i]))
            {
                bld.Append(" ");
            }
            bld.Append(stringVal[i]);
        }

        bld.Remove(0, 1);

        return bld.ToString();
    }

    /// <summary>
    /// Returns a random value from an enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }

}
