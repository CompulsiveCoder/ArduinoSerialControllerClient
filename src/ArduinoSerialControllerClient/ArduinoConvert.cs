using System;
//using NUnit.Framework;
//using duinocom;
//using System.Threading;
//using ArduinoSerialControllerClient;
//using System.Collections.Generic  ;

namespace ArduinoSerialControllerClient
{
	static public class ArduinoConvert
	{
        static public int PercentageToPWM(int percentageValue)
        {
            var fractionValue = (float)percentageValue/(float)100;
            
            var pwmValue = fractionValue*(float)255;
            
            return (int)pwmValue;
        }
        
        static public int PercentageToAnalog(int percentageValue)
        {
            var fractionValue = (float)percentageValue/(float)100;
            
            var pwmValue = fractionValue*(float)1024;
            
            return (int)pwmValue;
        }
        
        static public int AnalogToPercentage(int analogValue)
        {
            var fractionValue = (float)analogValue/(float)1024;
            
            var percentageValue = fractionValue*(float)100;
            
            return (int)percentageValue;
        }
        
        static public int ReversePercentage(int percentageValue)
        {
            return 100-percentageValue;
        }
	}
}