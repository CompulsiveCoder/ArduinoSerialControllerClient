using System;
using duinocom;

namespace ArduinoSerialControllerClient
{
    public class ArduinoSerialDevice
    {
        public DuinoCommunicator Communicator;
        
        public bool IsConnected = false;
        
        public ArduinoSerialDevice(string portName, int baudRate)
        {
            Communicator = new DuinoCommunicator(portName, baudRate);
        }
        
        public void Connect()
        {
            Communicator.Open();
            
            IsConnected = true;
        }
        
        public void Disconnect()
        {
            Communicator.Close();
            
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
            
            Communicator.Send(cmd);
        }
        
        public void AnalogWrite(int pinNumber, int value)
        {
            var cmd = String.Format("A{0}:{1}", pinNumber, value);
            
            Communicator.Send(cmd);
        }
        
        public void AnalogWritePercentage(int pinNumber, int value)
        {
            CheckConnected();
            
            Console.WriteLine("Analog writing percentage: " + value);
            
            var pwmValue = ArduinoConvert.PercentageToPWM(value);
            
            Console.WriteLine("Converted PWM value: " + pwmValue);
            
            var cmd = String.Format("A{0}:{1}", pinNumber, pwmValue);
            
            Console.WriteLine("Sending command: " + cmd);
            
            Communicator.Send(cmd);
        }
        
        public void CheckConnected()
        {
            if (!IsConnected)
                throw new Exception("Not connected. Call Connect() function before trying to communicate.");
        }
    }
}
