PACKAGE_NAME=$1
PACKAGE_VERSION=$2

if [ ! "$PACKAGE_NAME" ]; then
	echo "Please provide a package name as an argument."
	exit 1
fi

if [ ! "$PACKAGE_VERSION" ]; then
	echo "Please provide a package version as an argument."
	exit 1
fi

echo "Package name: $PACKAGE_NAME"
echo "Package version: $PACKAGE_VERSION"

PACKAGE_FILE="$PACKAGE_NAME.$PACKAGE_VERSION"
PACKAGE_FILE_EXT="$PACKAGE_NAME.$PACKAGE_VERSION.zip"

echo "Package file: $PACKAGE_FILE"

if [ ! -d "$PACKAGE_FILE" ]; then
	wget -q "https://github.com/GreenSense/libs/raw/master/$PACKAGE_FILE.zip" -O $PACKAGE_FILE_EXT || exit 1

	unzip -o "$PACKAGE_FILE_EXT" -d "$PACKAGE_FILE/" || exit 1
else
	echo "$PACKAGE_FILE library already exists. Skipping download."
fi
