using System;
using System.Collections.Generic;
using ISO8583;
using ISO8583.DataElement.Interfaces.DataSet;
using ISO8583.Maps.Visa;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            ReadMessage readMessage = new ReadMessage(new VisaMap(), "020042000400000000021612345678901234560609173030123456789ABC1000123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
            
            
        }
        
        
    }
}