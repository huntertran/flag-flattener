using System;

/// <summary>
/// A convenient attribute to decorate flattened classes of the class utilizing <seealso cref="System.FlagsAttribute"/>.
/// <br/>
/// For each type of enum, there should be a 
/// corresponding constructor, as generic attribute is not yet supported
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class FlattenedFlagAttribute : Attribute
{
    public Enum enumProperty;

    /// <summary>
    /// Constructor for Facility enum. For each type of enum, there should be
    /// a corresponding constructor, as generic attribute is not yet supported
    /// </summary>
    /// <param name="facility">the enum type</param>
    public FlattenedFlagAttribute(Facility facility)
    {
        this.enumProperty = facility;
    }

    /// <summary>
    /// Flatten the boolean data stored in an Enum field into an object.
    /// <br/>
    /// The method couldn't infer the type, as it's property is type of <seealso cref="System.Enum"/>, and generic attribute is not yet supported.
    /// </summary>
    /// <param name="type">Type of enum.</param>
    /// <param name="o">Object contains the flattened boolean data</param>
    /// <param name="enumData">The enum data, retrived directly from Database</param>
    public static void Flatten(Type type, object o, Enum enumData)
    {
        var props = type.GetProperties();

        foreach (var prop in props)
        {
            var attr = prop.GetCustomAttributes(typeof(FlattenedFlagAttribute), false);

            if (attr.GetLength(0) > 0)
            {
                prop.SetValue(o, enumData.HasFlag(((FlattenedFlagAttribute)attr[0]).enumProperty));
            }
        }
    }
}