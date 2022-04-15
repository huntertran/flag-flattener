using System;

[Flags]
public enum Facility
{
    None = 0,
    HasTV = 1,
    HasMicrowave = 2,
    HasOven = 4,
}