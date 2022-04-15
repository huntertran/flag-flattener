using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class FlattenedFlag : Attribute
{
    public Facility FacilityEnum;

    public FlattenedFlag(Facility facilityEnum)
    {
        this.FacilityEnum = facilityEnum;
    }
}