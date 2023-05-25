void setup() {
  Serial.begin(9600); // Set the baud rate to match the C# code
}

void loop() {
  int sensorValue =15; // Read a sensor value (you can replace this with your own data source)

  Serial.print("Sensor Value: ");
  Serial.println(sensorValue); // Send the sensor value to the serial port

  delay(1000);
  // Wait for 1 second before sending the next data
}
