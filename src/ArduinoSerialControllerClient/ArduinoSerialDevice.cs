using System;
using duinocom;

namespace ArduinoSerialControllerClient
{
    public class ArduinoSerialDevice
    {
        public SerialClient Client;
        
        public bool IsConnected = false;
        
        public ArduinoSerialDevice(string portName, int baudRate)
        {
            Client = new SerialClient(portName, baudRate);
        }
        
        public void Connect()
        {
            Client.Open();
            
            IsConnected = true;
        }
        
        public void Disconnect()
        {
            Client.Close();
            
            IsConnected = false;
        }
        
        public int DigitalRead(int pinNumber)
        {
            throw new NotImplementedException();
        }
        
        public int AnalogRead(int pinNumber)
        {
            throw new NotImplementedException();
        }
        
        public void DigitalWrite(int pinNumber, bool value)
        {
            var cmd = String.Format("A{0}:{1}", pinNumber, value);
            
            Client.Write(cmd);
        }
        
        public void AnalogWrite(int pinNumber, int value)
        {
            var cmd = String.Format("A{0}:{1}", pinNumber, value);
            
            Client.Write(cmd);
        }
        
        public void AnalogWritePercentage(int pinNumber, int value)
        {
            CheckConnected();
            
            Console.WriteLine("Analog writing percentage: " + value);
            
            var pwmValue = ArduinoConvert.PercentageToPWM(value);
            
            Console.WriteLine("Converted PWM value: " + pwmValue);
            
            var cmd = String.Format("A{0}:{1}", pinNumber, pwmValue);
            
            Console.WriteLine("Sending command: " + cmd);
            
            Client.Write(cmd);
        }
        
        public void CheckConnected()
        {
            if (!IsConnected)
                throw new Exception("Not connected. Call Connect() function before trying to communicate.");
        }
    }
}
