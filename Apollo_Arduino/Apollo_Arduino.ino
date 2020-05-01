#include "I2Cdev.h"
#include "MPU6050_6Axis_MotionApps20.h"
#if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
    #include "Wire.h"
#endif
MPU6050 mpu;
#define OUTPUT_READABLE_YAWPITCHROLL
#define INTERRUPT_PIN 2  // use pin 2 on Arduino Uno & most boards

bool dmpReady = false;  
uint8_t mpuIntStatus;   
uint8_t devStatus;      
uint16_t packetSize;    
uint16_t fifoCount;     
uint8_t fifoBuffer[64]; 

Quaternion q;
VectorInt16 aa;
VectorInt16 aaReal;
VectorInt16 aaWorld;
VectorFloat gravity;
float euler[3];
float ypr[3];

int i = 30;
int Lig = 0;
char led;
int d = 9;
int sens;
int Xmin = 1;
int Xmax = 2;
int calibrado = 0;

int temp = 0;

volatile bool mpuInterrupt = false; 
void dmpDataReady() {
    mpuInterrupt = true;
}

void setup() {
    #if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
        Wire.begin();
        Wire.setClock(400000);
    #elif I2CDEV_IMPLEMENTATION == I2CDEV_BUILTIN_FASTWIRE
        Fastwire::setup(400, true);
    #endif

    Serial.begin(115200);
    while (!Serial);
    mpu.initialize();
    pinMode(INTERRUPT_PIN, INPUT);
    while (Serial.available() && Serial.read());
    while (!Serial.available());                
    while (Serial.available() && Serial.read());
    devStatus = mpu.dmpInitialize();
    mpu.setXGyroOffset(220);
    mpu.setYGyroOffset(76);
    mpu.setZGyroOffset(-85);
    mpu.setZAccelOffset(1788);

    if (devStatus == 0) {
        mpu.setDMPEnabled(true);
        attachInterrupt(digitalPinToInterrupt(INTERRUPT_PIN), dmpDataReady, RISING);
        mpuIntStatus = mpu.getIntStatus();
        dmpReady = true;

        packetSize = mpu.dmpGetFIFOPacketSize();
    } else {
    }
}

void loop() {

    if (!dmpReady) return;
    while (!mpuInterrupt && fifoCount < packetSize) {
    }

    mpuInterrupt = false;
    mpuIntStatus = mpu.getIntStatus();
    fifoCount = mpu.getFIFOCount();
    if ((mpuIntStatus & 0x10) || fifoCount == 1024) {
        mpu.resetFIFO();
    } else if (mpuIntStatus & 0x02) {
        while (fifoCount < packetSize) fifoCount = mpu.getFIFOCount();
        mpu.getFIFOBytes(fifoBuffer, packetSize);
        fifoCount -= packetSize;
        #ifdef OUTPUT_READABLE_YAWPITCHROLL
          if(temp < 2000){
            mpu.dmpGetQuaternion(&q, fifoBuffer);
            mpu.dmpGetGravity(&gravity, &q);
            mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
           // Serial.println(ypr[0] * 180/M_PI);
          }
          if(temp > 2000 && calibrado == 0){
            if(Serial.available() && Serial.read() == '1'){
              mpu.dmpGetQuaternion(&q, fifoBuffer);
            mpu.dmpGetGravity(&gravity, &q);
            mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
           // Serial.println(ypr[0] * 180/M_PI);
            d = ypr[0] * 180/M_PI;
            Lig = 12;
            Xmin = d;
            calibrado = 1;
            }
          }
          if(temp > 2000 && calibrado == 1){
            if(Serial.available() && Serial.read() == '2'){
              mpu.dmpGetQuaternion(&q, fifoBuffer);
            mpu.dmpGetGravity(&gravity, &q);
            mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
           // Serial.println(ypr[0] * 180/M_PI);
            d = ypr[0] * 180/M_PI;
            Lig = 1;
            Xmax = d;
            sens = sens = (Xmax-Xmin)/12;
            calibrado = 2;
            }
          }
          if(temp > 2000 && calibrado == 2){
            mpu.dmpGetQuaternion(&q, fifoBuffer);
            mpu.dmpGetGravity(&gravity, &q);
            mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
            //Serial.println(ypr[0] * 180/M_PI);
            d = ypr[0] * 180/M_PI;
             if (d > Xmin && d <= (Xmin + sens))
            {
                Lig = 12;
                Serial.print("1\n");
            }
            if (d > (Xmin + sens) && d <= (Xmin + 2 * sens))
            {
                Lig = 11;
                Serial.print("2\n");
            }
            if (d > (Xmin + 2 * sens) && d <= (Xmin + 3 * sens))
            {
                Lig = 10;
                Serial.print("3\n");
            }
            if (d > (Xmin + 3 * sens) && d <= (Xmin + 4 * sens))
            {
                Lig = 9;
                Serial.print("4\n");
            }
            if (d > (Xmin + 4 * sens) && d <= (Xmin + 5 * sens))
            {
                Lig = 8;
                Serial.print("5\n");
            }
            if (d > (Xmin + 5 * sens) && d <= (Xmin + 6 * sens))
            {
                Lig = 7;
                Serial.print("6\n");
            }
            if (d > (Xmin + 6 * sens) && d <= (Xmin + 7 * sens))
            {
                Lig = 6;
                Serial.print("7\n");
            }
            if (d > (Xmin + 7 * sens) && d <= (Xmin + 8 * sens))
            {
                Lig = 5;
                Serial.print("8\n");
            }
            if (d > (Xmin + 8 * sens) && d <= (Xmin + 9 * sens))
            {
                Lig = 4;
                Serial.print("9\n");
            }
            if (d > (Xmin + 9 * sens) && d <= (Xmin + 10 * sens))
            {
                Lig = 3;
                Serial.print("10\n");
            }
            if (d > (Xmin + 10 * sens) && d <= (Xmin + 11 * sens))
            {
                Lig = 2;
                Serial.print("11\n");
            }
            if (d > (Xmin + 11 * sens) && d <= (Xmin + 12 * sens))
            {
                Lig = 1;
                Serial.print("12\n");
            }
          }

            //Serial.println(temp);
            temp = temp + 1;
            delay(1);
        #endif

    }
  for(i = 30; i <= 52; i = i + 2){
   if(i != 28+(Lig*2)){
    pinMode(i,OUTPUT);
    i = i + 1;
    pinMode(i,INPUT);
    i = i - 1;
    digitalWrite(i,LOW);
    }
  }
   Lig = 28 + ( 2 * Lig );
   pinMode(Lig, INPUT);
   Lig = Lig + 1;
   pinMode(Lig, OUTPUT);
   digitalWrite(Lig,LOW);
   Lig = Lig - 1;
   Lig = (Lig - 28)/2;
}
