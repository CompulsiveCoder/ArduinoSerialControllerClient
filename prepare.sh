echo "Preparing for ArduinoSerialControllerClient project"
echo "Dir: $PWD"

git submodule update --init

DIR=$PWD

sudo apt-get update

if ! type "git" > /dev/null; then
  sudo apt-get install -y git
fi

if ! type "wget" > /dev/null; then
  sudo apt-get install -y wget
fi

if ! type "mono" > /dev/null; then
#  sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
#  echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list

  sudo apt-get install -y mono-devel mono-complete
fi

cd lib/duinocom.core && \
sudo sh prepare.sh && \
cd $DIR
