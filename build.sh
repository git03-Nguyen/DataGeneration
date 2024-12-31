#!/bin/bash

# Paths setup
SCRIPT_DIR=$(dirname "$0")
SRC_DIR="$SCRIPT_DIR"
PUBLISH_DIR="$SCRIPT_DIR/publish"

# Clean previous build artifacts
echo "Cleaning previous build artifacts..."
dotnet clean "$SRC_DIR/MDataGeneration.csproj" -c Release

if [ $? -ne 0 ]; then
  echo "Clean failed. Exiting."
  exit 1
fi

# Restore NuGet packages
echo "Restoring NuGet packages..."
dotnet restore "$SRC_DIR/MDataGeneration.csproj"

if [ $? -ne 0 ]; then
  echo "NuGet restore failed. Exiting."
  exit 1
fi

# Build and publish the project
echo "Building and publishing the project..."
dotnet publish "$SRC_DIR/MDataGeneration.csproj" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -o "$PUBLISH_DIR"

if [ $? -eq 0 ]; then
  echo "Build succeeded. The executable is located in $PUBLISH_DIR."
else
  echo "Build failed."
  exit 1
fi
