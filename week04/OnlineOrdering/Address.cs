using System;
using System.Collections.Generic;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvidence;
    private string _county;

    public Address(string street, string city, string stateOrProvidence, string county)
    {
        _street = street;
        _city = city;
        _stateOrProvidence = stateOrProvidence;
        _county = county;
    }

    public bool IsInUsa()
    {
        return _county.ToLower() == "usa";
    }

    public string GetFormatAddress()
    {
        return $"{_street} {_city}, {_stateOrProvidence} {_county}";
    }
}