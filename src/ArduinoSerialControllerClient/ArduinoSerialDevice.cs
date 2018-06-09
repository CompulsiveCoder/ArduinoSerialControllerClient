using System;
using System.Threading;
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

		public bool DigitalRead(int pinNumber)
		{
			var cmd = String.Format("D{0}:R", pinNumber);

			Client.WriteLine(cmd);

			var output = Client.ReadLine().Trim();

			var digitalValue = 0;
			if (!Int32.TryParse(output, out digitalValue))
				throw new Exception("Failed to convert digital pin value: " + output);

			return digitalValue == 1;
		}

		public int AnalogRead(int pinNumber)
		{
			var cmd = String.Format("A{0}:R", pinNumber);

			Client.WriteLine(cmd);

			var output = Client.ReadLine().Trim();

			var analogValue = 0;
			if (!Int32.TryParse(output, out analogValue))
				throw new Exception("Failed to convert analog pin value: " + output);

			return analogValue;
		}

		public void DigitalWrite(int pinNumber, bool value)
		{
			var cmd = String.Format("A{0}:{1}", pinNumber, value);

			Client.WriteLine(cmd);
		}

		public void AnalogWrite(int pinNumber, int value)
		{
			var cmd = String.Format("A{0}:{1}", pinNumber, value);

			Client.WriteLine(cmd);
		}

		public void AnalogWritePercentage(int pinNumber, int value)
		{
			CheckConnected();

			Console.WriteLine("Analog writing percentage: " + value);

			var pwmValue = ArduinoConvert.PercentageToPWM(value);

			Console.WriteLine("Converted PWM value: " + pwmValue);

			var cmd = String.Format("A{0}:{1}", pinNumber, pwmValue);

			Console.WriteLine("Sending command: " + cmd);

			Client.WriteLine(cmd);
		}

		public void CheckConnected()
		{
			if (!IsConnected)
				throw new Exception("Not connected. Call Connect() function before trying to communicate.");
		}
	}
}
