echo "Getting libraries for project"
echo "Dir: $PWD"

cert-sync --quiet /etc/ssl/certs/ca-certificates.crt

NUGET_FILE="nuget.exe"

if [ ! -f "$NUGET_FILE" ];
then
    curl -O http://nuget.org/nuget.exe
fi

mono nuget.exe install nunit -version 2.6.4
mono nuget.exe install nunit.runners -version 2.6.4

git clone http://github.com/CompulsiveCoder/duinocom.git
cd duinocom
sh init.sh &&
sh build.sh
