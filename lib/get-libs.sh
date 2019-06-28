echo "Getting library files..."
echo "  Dir: $PWD"

bash install-package-from-github-release.sh CompulsiveCoder duinocom.core 1.2.0.23

# Disabled. Not yet implemented
#sh install-package.sh NUnit 2.6.4
#sh install-package.sh NUnit.Runners 2.6.4

echo "Finished getting library files."
