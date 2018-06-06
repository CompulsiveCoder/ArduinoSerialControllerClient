#!/bin/bash

echo "Getting libraries for ArduinoSerialControllerClient project"
echo "Dir: $PWD"

NUGET_FILE="nuget.exe"

if [ ! -f "$NUGET_FILE" ];
then
    wget http://nuget.org/nuget.exe
fi

mono nuget.exe update -self

if [ ! -d "duinocom.core.1.0.6" ]; then
    mono nuget.exe install duinocom.core -version 1.0.6
fi

#if [ ! -d "NUnit.2.6.4" ]; then
#    mono nuget.exe install nunit -version 2.6.4
#fi

#if [ ! -d "NUnit.Runners.2.6.4" ]; then
#    mono nuget.exe install nunit.runners -version 2.6.4
#fi
