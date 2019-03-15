namespace ISO8583.DataElement
{
    public enum DATA_TYPE
    {
        
        N,//numeric
        A,//Alphabetic
        AN//alphanumeric
       
    }

    public enum LENGTH_TYPE
    {
        FIX,
        
        
        //0<LV<10<LLV<100<LLLV<1000
        
        LV,//variable length not sure if it still in use
        LLV,
        LLLV
    }
    
    
}