namespace Day05;

public class RangeMapping
{
    public long SourceStart { get; set; }
    public long DestStart { get; set; }
    public long Length { get; set; }

    public bool Contains(long number)
    {
        return number >= SourceStart && number < SourceStart + Length;
    }

    public long MapNumber(long number)
    {
        return DestStart + (number - SourceStart);
    }
}