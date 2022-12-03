#include <ArduinoJson.h>
#include <Servo.h>
#include <ESP8266WiFi.h>
#include <PubSubClient.h>


Servo myservo;

const char* ssid = "ssid";
const char* password = "password";
const char* id="TG_001";
const char* mqtt_server = "test.mosquitto.org";

WiFiClient espClient;
PubSubClient client(espClient);
StaticJsonDocument<100> keepalive;


long min_counter;
long time_limit;
unsigned long old_time;

int opened;
int closed;

void setup() {
  myservo.attach(2);
  min_counter = 0;
  time_limit = 300000;
  opened=90;
  closed=0;

  keepalive["gate"]=id;
  keepalive["operation"]="keepalive";
  
  setupWifi();
  myservo.write(closed);

  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);
}

void loop() {

  if (!client.connected()) {
    reconnect();
  }
  client.loop();
  timeCheck();

}

void timeCheck(){
  unsigned long new_time = millis();
  unsigned long time_difference = new_time - old_time;

  old_time=new_time;
  min_counter = min_counter + time_difference;

  if(min_counter > time_limit){
    min_counter = 0;

    char buffer[256];
    serializeJson(keepalive, buffer);
    
    client.publish("foi/air2220",buffer);
  }

}

void operateGate(){
  
  myservo.write(opened);
  delay(10000);
  myservo.write(closed);
}

void setupWifi(){

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
  }
}

void reconnect() {
  
  while (!client.connected()) {
    String clientId = "ESP8266Client-";
    clientId += String(random(0xffff), HEX);

    if (client.connect(clientId.c_str())) {
      client.subscribe("foi/air2220");
    } else {
      delay(5000);
    }
  }
}


void callback(char* topic, byte* payload, unsigned int length) {

  StaticJsonDocument<256> doc;
  deserializeJson(doc, payload, length);
 
  if(doc["gate"]==id && doc["operation"]=="open"){
    operateGate();
  }
}

