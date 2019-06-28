echo "Packaging release zip file..."

. ./project.settings

DIR=$PWD

TMP_RELEASE_FOLDER=".tmp/$PROJECT_NAME/lib/net40/"
BIN_RELEASE_FOLDER="bin/Release"
RELEASES_FOLDER="releases"

BRANCH=$(git branch | sed -n -e 's/^\* \(.*\)/\1/p')

VERSION_POSTFIX=""

if [ "$BRANCH" = "dev" ]; then
  VERSION_POSTFIX="-dev"
fi

VERSION="$(cat version.txt).$(cat buildnumber.txt)"

mkdir -p $TMP_RELEASE_FOLDER

cp $BIN_RELEASE_FOLDER/$PROJECT_NAME.dll $TMP_RELEASE_FOLDER/
cp $BIN_RELEASE_FOLDER/$PROJECT_NAME.dll.mdb $TMP_RELEASE_FOLDER/
cp $BIN_RELEASE_FOLDER/duinocom.core.dll $TMP_RELEASE_FOLDER/

mkdir -p $RELEASES_FOLDER

cd .tmp/

zip -r $DIR/releases/$PROJECT_NAME.$VERSION$VERSION_POSTFIX.zip $PROJECT_NAME

cd $DIR

rm .tmp -r

echo "Finished packaging release zip file."
