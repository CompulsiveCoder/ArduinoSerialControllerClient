DIR=$PWD

echo "Initializing ArduinoSerialControllerClient project"
echo "Dir: $PWD"

cd lib
sh get-libs.sh
cd $DIR

cd lib/duinocom && \
sh init.sh && \
sh build.sh && \ # Build here so it only needs to happen once
cd $DIR
