#!/bin/bash

# Set the publish directory path
PUBLISH_DIR="./publish"
EXE_PATH="$PUBLISH_DIR/MDataGeneration.exe"

# Check if the publish directory exists
if [ ! -d "$PUBLISH_DIR" ]; then
  echo "Publish directory '$PUBLISH_DIR' does not exist. Please run 'build.sh' first to generate the executable."
  exit 1
fi

# Run the executable with arguments
echo "Running the executable..."
"$EXE_PATH" --users 50 --brands 5 --categories 50 --products 1000 --invoices 1000 --export sql,csv,json

# Check if the command succeeded
if [ $? -eq 0 ]; then
  echo "Execution completed successfully. Data is located in ./output."
else
  echo "Execution failed."
  exit 1
fi
