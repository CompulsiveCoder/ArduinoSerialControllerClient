DIR=$PWD

echo "Initializing ArduinoSerialControllerClient project"
echo "Dir: $PWD"

cd lib && \
sh get-libs.sh && \
cd $DIR
