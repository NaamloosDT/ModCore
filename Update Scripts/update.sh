#!/bin/bash
if [ -z "$4" ]
then
    echo "Relaunching"
    nohup bash "$0" "$1" "$2" "$3" "yee"
    exit
fi

echo "Waiting for process to terminate"
wait "$1"

echo "Beginning update package download"
curl -LO "https://ci.appveyor.com/api/projects/NaamloosDT/modcore/artifacts/ModCore/bin/Release/ModCore%20Release%20Build.zip" -o update.zip

echo "Beginning archive extraction"
unzip -o ModCore%20Release%20Build.zip

echo "Restarting process"
dotnet ModCore.dll $2 $3
