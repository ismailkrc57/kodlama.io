﻿namespace Core.Persistence.Dynamic;

public class Sort
{
    public Sort()
    {
    }

    public Sort(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }

    public string Field { get; set; }
    public string Dir { get; set; }
}