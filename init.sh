DIR=$PWD

echo "Initializing ArduinoSerialControllerClient project"
echo "Dir: $PWD"

cd lib/duinocom.core && \
sh init.sh && \
sh build.sh && \
cd $DIR && \

cd lib && \
sh get-libs.sh && \
cd $DIR
