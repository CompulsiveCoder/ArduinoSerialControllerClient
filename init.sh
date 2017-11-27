DIR=$PWD

echo "Initializing duinocom project"
echo "Dir: $PWD"

cd lib
sh get-libs.sh
cd $DIR
