echo "Starting build for ArduinoSerialControllerClient project"
echo "Dir: $PWD"

MODE=$1

if [ -z "$MODE" ]; then
    MODE="Release"
fi

echo "Mode: $MODE"

xbuild src/ArduinoSerialControllerClient.sln /p:Configuration=$MODE
