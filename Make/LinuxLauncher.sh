echo "Check Status of Required Packages"
echo "You may need to provide root access to install"

#install mono-Runtime
sudo apt-get install mono-complete mono-mcs mono-xsp2 mono-xsp2-base

#Set IO Mapping
echo "Setting up environment"
export MONO_IOMAP=all

echo "Which application do you want to run?"
echo "1: Legend of Drongo Engine"
echo "2: Legend of Drongo World Designer"
read Choice
if [ $Choice == 1 ]; then
	echo "Launching game"
	mono Legend\ Of\ Drongo.exe
elif [ $Choice == 2 ]; then
	echo "Launching world designer"
	mono Legend\ Of\ Drongo\ World\ Designer.exe
else
	echo "I'm afraid I can't do that"
fi
