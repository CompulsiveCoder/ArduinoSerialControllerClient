using System;
using System.Threading;
using duinocom;

namespace ArduinoSerialControllerClient
{
    public class ArduinoSerialDevice2
    {
        public SerialClient Client;
        
        public bool IsConnected = false;

        public ArduinoSerialDevice2 (string portName, int baudRate)
        {
            Client = new SerialClient (portName, baudRate);
        }

        public void Connect ()
        {
            Client.Open ();
            
            IsConnected = true;
        }

        public void Disconnect ()
        {
            Client.Close ();
            
            IsConnected = false;
        }

        public bool DigitalRead (int pinNumber)
        {
            var cmd = String.Format ("D{0}:R", pinNumber);
            
            Client.WriteLine (cmd);

            Thread.Sleep (1000);

            var output = Client.Read ();

            var digitalValue = Convert.ToInt32 (output.Trim ()) == 1;

            return digitalValue;
        }

        public int AnalogRead (int pinNumber)
        {
            var cmd = String.Format ("A{0}:R", pinNumber);
            
            Client.WriteLine (cmd);

            Thread.Sleep (1000);

            var output = Client.Read ();

            var analogValue = Convert.ToInt32 (output.Trim ());

            return analogValue;
        }

        public void DigitalWrite (int pinNumber, bool value)
        {
            var cmd = String.Format ("A{0}:{1}", pinNumber, value);
            
            Client.WriteLine (cmd);
        }

        public void AnalogWrite (int pinNumber, int value)
        {
            var cmd = String.Format ("A{0}:{1}", pinNumber, value);
            
            Client.WriteLine (cmd);
        }

        public void AnalogWritePercentage (int pinNumber, int value)
        {
            CheckConnected ();
            
            Console.WriteLine ("Analog writing percentage: " + value);
            
            var pwmValue = ArduinoConvert.PercentageToPWM (value);
            
            Console.WriteLine ("Converted PWM value: " + pwmValue);
            
            var cmd = String.Format ("A{0}:{1}", pinNumber, pwmValue);
            
            Console.WriteLine ("Sending command: " + cmd);
            
            Client.WriteLine (cmd);
        }

        public void PinMode (int pinNumber, PinMode pinMode)
        {
            CheckConnected ();

            Console.WriteLine ("Setting pin mode...");
            Console.WriteLine ("  Pin number: " + pinNumber);
            Console.WriteLine ("  Pin mode: " + pinMode.ToString ());

            var cmd = String.Format ("M{0}:{1}", pinNumber, (int)pinMode);


            Console.WriteLine ("Sending command: " + cmd);

            Client.WriteLine (cmd);
        }

        public void CheckConnected ()
        {
            if (!IsConnected)
                throw new Exception ("Not connected. Call Connect() function before trying to communicate.");
        }
    }
}
