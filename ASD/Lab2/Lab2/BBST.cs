namespace Lab2;

class BBST
{
    public int Data { get; set; }
    public BBST Left { get; set; }
    public BBST Right { get; set; }

    public BBST(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}